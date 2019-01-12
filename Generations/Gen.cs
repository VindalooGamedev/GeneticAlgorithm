using System;

namespace GeneticAlgorithms {
    public class Gen<TGene> {
        public enum FitSortConfig {
            None = 0,
            Offs = 1, Pars = 2,
            ParsAndOffs = 4, ParsAndOffsTogether = 8
        }

        private enum FitSortNeeds { None = 0, Offs = 1, Pars = 2 }

        private IChromoInt<TGene>[] _chromos;

        private FitSortConfig _fitSortConfig;
        public FitSortConfig SortConfig {
            get => _fitSortConfig;
            set {
                _fitSortConfig = value;
                switch (value) {
                    case FitSortConfig.None: _sortNeeds = FitSortNeeds.None; break;
                    case FitSortConfig.Offs: _sortNeeds = FitSortNeeds.Offs; break;
                    case FitSortConfig.Pars: _sortNeeds = FitSortNeeds.Pars; break;
                    case FitSortConfig.ParsAndOffs:
                        _sortNeeds = FitSortNeeds.Offs | FitSortNeeds.Pars;
                        break;
                    case FitSortConfig.ParsAndOffsTogether:
                        _sortNeeds = FitSortNeeds.Offs | FitSortNeeds.Pars;
                        break;
                }
            }
        }

        private FitSortNeeds _mustBeSorted;
        private FitSortNeeds _sortNeeds;

        private bool MustBeSorted => (_mustBeSorted & _sortNeeds) != FitSortNeeds.None;

        private int _offsLength;
        public int OffsLength {
            get => _offsLength;
            set {
                _offsLength = value;
                _parsLength = _chromos.Length - _offsLength;
            }
        }

        private int _parsLength;
        public int ParsLength {
            get => _parsLength;
            set {
                _parsLength = value;
                _offsLength = _chromos.Length - _parsLength;
            }
        }

        public int MinFit { get; private set; }
        public int MaxFit { get; private set; }
        public int GenCount { get; private set; } = 0;

        public IChromoInt<TGene> GetPar(int i) {
            _mustBeSorted |= FitSortNeeds.Pars;
            return _chromos[i];
        }

        public IChromoInt<TGene> GetOff(int i) {
            _mustBeSorted |= FitSortNeeds.Offs;
            return _chromos[OffAddress(i)];
        }

        private int OffAddress(int i) => _chromos.Length - OffsLength + i;

        public Gen(IChromoInt<TGene>[] chromos) => _chromos = chromos;

        public void UpdateData() {
            GenCount++;

            if (MustBeSorted) {
                switch (_fitSortConfig) {
                    case FitSortConfig.Offs: SortOffsByFit(); break;
                    case FitSortConfig.Pars: SortParsByFit(); break;
                    case FitSortConfig.ParsAndOffs:
                        SortOffsByFit();
                        SortParsByFit();
                        break;
                    case FitSortConfig.ParsAndOffsTogether: SortAllByFit(); break;
                }
                _mustBeSorted = FitSortNeeds.None;
            }

            if ((int)_fitSortConfig > 1) {
                MinFit = GetPar(ParsLength - 1).Fit;
                MaxFit = GetPar(0).Fit;
            }
            else {
                MaxFit = int.MinValue;
                MinFit = int.MaxValue;
                for (int i = 0; i < ParsLength; i++) {
                    int observedFit = GetPar(i).Fit;
                    if (observedFit > MaxFit) { MaxFit = observedFit; }
                    if (observedFit < MinFit) { MinFit = observedFit; }
                }
            }
        }


        public void Switch(int parentId, int offspringId) {
            IChromoInt<TGene> auxParent = GetPar(parentId);
            _chromos[parentId] = GetOff(offspringId);
            _chromos[OffAddress(offspringId)] = auxParent;
            _mustBeSorted = FitSortNeeds.Offs | FitSortNeeds.Pars;
        }

        public void FullSwitch() {
            SwitchChunk((ParsLength <= OffsLength) ? ParsLength : OffsLength);
            _mustBeSorted = FitSortNeeds.Offs | FitSortNeeds.Pars;
        }

        public void SwitchChunk(int length) {
            IChromoInt<TGene>[] auxArray = new IChromoInt<TGene>[length];
            int chunkOffset = ParsLength - length;

            Array.Copy(_chromos, chunkOffset, auxArray, 0, length);
            Array.Copy(_chromos, OffAddress(0), _chromos, chunkOffset, length);
            Array.Copy(auxArray, 0, _chromos, OffAddress(0), length);
            _mustBeSorted = FitSortNeeds.Offs | FitSortNeeds.Pars;
        }

        private void SortAllByFit() => SortByFit(_chromos);

        private void SortByFit(IChromoInt<TGene>[] chromoArray)
            => Array.Sort(chromoArray, (a, b) => b.Fit - a.Fit);

        private void SortParsByFit() => SortByFit(0, ParsLength);

        private void SortOffsByFit() => SortByFit(OffAddress(0), OffsLength);

        private void SortByFit(int origin, int length) {
            IChromoInt<TGene>[] auxArray = new IChromoInt<TGene>[ParsLength];

            Array.Copy(_chromos, origin, auxArray, 0, length);
            SortByFit(auxArray);
            Array.Copy(auxArray, 0, _chromos, origin, length);
        }
    }
}

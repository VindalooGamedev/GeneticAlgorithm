using System;

namespace GeneticAlgorithms {
    public class GenerationalGen<TGene> : GenBase<TGene> {
        private bool _sortedByFitness;
        private bool _generationalPure;

        private int _offspringLength;
        public override int OffsLength => _offspringLength;

        private int _parentsLength;
        public override int ParsLength => _parentsLength;

        private int _minimumFitness;
        public override int MinFit => _minimumFitness;

        private int _maximumFitness;
        public override int MaxFit => _maximumFitness;

        // Only parents will be sorted by fitness
        public GenerationalGen(
            IChromoInt<TGene>[] chromosomes,
            int parentsAmount,
            bool FitSorted,
            bool generationalPure)
            : base(chromosomes) {
            _parentsLength = parentsAmount;
            _offspringLength = chromosomes.Length - parentsAmount;
            _sortedByFitness = FitSorted;
            _generationalPure = generationalPure;
        }

        public override IChromoInt<TGene> GetPar(int index)
            => _chromo[index];

        public override void SetPar(int index, IChromoInt<TGene> chromosome)
            => _chromo[index] = chromosome;

        public override IChromoInt<TGene> GetOff(int index)
            => _chromo[_parentsLength + index];

        public override void SetOffs(int index, IChromoInt<TGene> chromosome)
            => _chromo[_parentsLength + index] = chromosome;

        // For generational pure it must be 50/50 distribution
        protected override void OnStartNewGeneration() {
            if (_generationalPure) {
                IChromoInt<TGene>[] auxArray = new IChromoInt<TGene>[ParsLength];
                Array.Copy(_chromo, 0, auxArray, 0, ParsLength);
                Array.Copy(_chromo, ParsLength, _chromo, 0, OffsLength);
                Array.Copy(auxArray, 0, _chromo, OffsLength, ParsLength);
            }
            SortIfNeeded();
        }

        private void SortIfNeeded() {
            if (_sortedByFitness) {
                // Prepare auxiliar data holder.
                IChromoInt<TGene>[] auxArray = new IChromoInt<TGene>[ParsLength];

                // Copy parents to aux then sort and copy back.
                Array.Copy(_chromo, 0, auxArray, 0, ParsLength);
                SortByFitness(auxArray);
                Array.Copy(auxArray, 0, _chromo, 0, ParsLength);

                // It's sorted by fitness so Min & Max are easily addressable
                _maximumFitness = _chromo[0].Fit;
                _minimumFitness = _chromo[ParsLength - 1].Fit;
            }
            else {
                _maximumFitness = int.MinValue;
                _minimumFitness = int.MaxValue;
                for (int i = 0; i < ParsLength; i++) {
                    int observedFitness = GetPar(i).Fit;
                    if (observedFitness > _maximumFitness) {
                        _maximumFitness = observedFitness;
                    }
                    if (observedFitness < _minimumFitness) {
                        _minimumFitness = observedFitness;
                    }
                }
            }
        }
    }
}

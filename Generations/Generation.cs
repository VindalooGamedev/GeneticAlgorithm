using System;

namespace GeneticAlgorithms {
    public class Generation<TGene> : GenerationBase<TGene> {
        private bool _isUnsorted = true;
        public bool FitSorted { get; set; }

        private int _offspringLength;
        public override int OffspringLength => _offspringLength;

        private int _parentsLength;
        public override int ParentsLength => _parentsLength;

        private int _minFit;
        public override int MinFit => _minFit;

        private int _maxFit;
        public override int MaxFit => _maxFit;

        public Generation(IChromosomeInt<TGene>[] chromosomes) : base(chromosomes)
            => _chromosomes = chromosomes;

        public void Switch(int parentId, int offspringId) {
            IChromosomeInt<TGene> auxParent = GetParent(parentId);
            _chromosomes[parentId] = GetOffspring(offspringId);
            _chromosomes[OffspringAdress(offspringId)] = auxParent;
        }

        public void FullSwitch() {
            IChromosomeInt<TGene>[] auxArray;
            if (ParentsLength <= OffspringLength) {
                auxArray = new IChromosomeInt<TGene>[ParentsLength];

                Array.Copy(_chromosomes, 0, auxArray, 0, ParentsLength);
                Array.Copy(_chromosomes, OffspringAdress(0), _chromosomes, 0, ParentsLength);
                Array.Copy(auxArray, 0, _chromosomes, OffspringAdress(0), ParentsLength);
                return;
            }
            else {
                auxArray = new IChromosomeInt<TGene>[OffspringLength];
                int chunkOffset = ParentsLength - OffspringLength;

                Array.Copy(_chromosomes, chunkOffset, auxArray, 0, OffspringLength);
                Array.Copy(_chromosomes, OffspringAdress(0), _chromosomes, chunkOffset, OffspringLength);
                Array.Copy(auxArray, 0, _chromosomes, OffspringAdress(0), OffspringLength);
                return;
            }
        }

        public void SortByFitness() => SortByFitness(_chromosomes);

        public void SortParentByFitness() {
            IChromosomeInt<TGene>[] auxArray = new IChromosomeInt<TGene>[ParentsLength];

            // Copy parents to aux then sort and copy back.
            Array.Copy(_chromosomes, 0, auxArray, 0, ParentsLength);
            SortByFitness(auxArray);
            Array.Copy(auxArray, 0, _chromosomes, 0, ParentsLength);
        }

        public void SortOffspringsByFitness() {
            IChromosomeInt<TGene>[] auxArray = new IChromosomeInt<TGene>[ParentsLength];

            // Copy parents to aux then sort and copy back.
            Array.Copy(_chromosomes, OffspringAdress(0), auxArray, 0, OffspringLength);
            SortByFitness(auxArray);
            Array.Copy(auxArray, 0, _chromosomes, OffspringAdress(0), OffspringLength);
        }

        public override IChromosomeInt<TGene> GetParent(int index)
            => _chromosomes[index];

        public override IChromosomeInt<TGene> GetOffspring(int index)
            => _chromosomes[OffspringAdress(index)];

        private int OffspringAdress(int index)
            => _chromosomes.Length - OffspringLength + index;

        protected override void OnStartNewGeneration() {
            if (FitSorted) {
                SortByFitness();
            }
            throw new NotImplementedException();
        }

        public override void SetOffspring(int offspringIndex, IChromosomeInt<TGene> chromosome)
            => throw new System.NotImplementedException();

        public override void SetParent(int parentIndex, IChromosomeInt<TGene> chromosome)
            => throw new System.NotImplementedException();
    }
}

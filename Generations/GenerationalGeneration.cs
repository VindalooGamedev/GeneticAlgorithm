using System;

namespace GeneticAlgorithms {
    public class GenerationalGeneration<TGene> : Generation<TGene> {
        private bool _sortedByFitness;
        private bool _generationalPure;

        private int _offspringLength;
        public override int OffspringLength => _offspringLength;

        private int _parentsLength;
        public override int ParentsLength => _parentsLength;

        private int _minimumFitness;
        public override int MinimumFitness => _minimumFitness;

        private int _maximumFitness;
        public override int MaximumFitness => _maximumFitness;

        // Only parents will be sorted by fitness
        public GenerationalGeneration(
            IChromosomeInt<TGene>[] chromosomes,
            int parentsAmount,
            bool sortedByFitness,
            bool generationalPure)
            : base(chromosomes) {
            _parentsLength = parentsAmount;
            _offspringLength = chromosomes.Length - parentsAmount;
            _sortedByFitness = sortedByFitness;
            _generationalPure = generationalPure;
        }

        public override IChromosomeInt<TGene> GetParent(int index)
            => _chromosomes[index];

        public override void SetParent(int index, IChromosomeInt<TGene> chromosome)
            => _chromosomes[index] = chromosome;

        public override IChromosomeInt<TGene> GetOffspring(int index)
            => _chromosomes[_parentsLength + index];

        public override void SetOffspring(int index, IChromosomeInt<TGene> chromosome)
            => _chromosomes[_parentsLength + index] = chromosome;

        // For generational pure it must be 50/50 distribution
        protected override void OnStartNewGeneration() {
            if (_generationalPure) {
                IChromosomeInt<TGene>[] auxArray = new IChromosomeInt<TGene>[ParentsLength];
                Array.Copy(_chromosomes, 0, auxArray, 0, ParentsLength);
                Array.Copy(_chromosomes, ParentsLength, _chromosomes, 0, OffspringLength);
                Array.Copy(auxArray, 0, _chromosomes, OffspringLength, ParentsLength);
            }
            SortIfNeeded();
        }

        private void SortIfNeeded() {
            if (_sortedByFitness) {
                // Prepare auxiliar data holder.
                IChromosomeInt<TGene>[] auxArray = new IChromosomeInt<TGene>[ParentsLength];

                // Copy parents to aux then sort and copy back.
                Array.Copy(_chromosomes, 0, auxArray, 0, ParentsLength);
                SortByFitness(auxArray);
                Array.Copy(auxArray, 0, _chromosomes, 0, ParentsLength);

                // It's sorted by fitness so Min & Max are easily addressable
                _maximumFitness = _chromosomes[0].Fitness;
                _minimumFitness = _chromosomes[ParentsLength - 1].Fitness;
            }
            else {
                _maximumFitness = int.MinValue;
                _minimumFitness = int.MaxValue;
                for (int i = 0; i < ParentsLength; i++) {
                    int observedFitness = GetParent(i).Fitness;
                    if (observedFitness > _maximumFitness) _maximumFitness = observedFitness;
                    if (observedFitness < _minimumFitness) _minimumFitness = observedFitness;
                }
            }
        }
    }
}

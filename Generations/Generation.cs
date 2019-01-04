using System;

namespace GeneticAlgorithms {
    // Abstract class that defines the minimum requisites for each type of Generation.
    public abstract class Generation<TGene> : IQueryableByTerminationCondition {
        protected IChromosomeInt<TGene>[] _chromosomes;

        public int GenerationCount { get; private set; } = 0;

        public abstract int MinimumFitness { get; }
        public abstract int MaximumFitness { get; }

        public abstract int ParentsLength { get; }
        public abstract IChromosomeInt<TGene> GetParent(int index);
        public abstract void SetParent(int parentIndex, IChromosomeInt<TGene> chromosome);

        public abstract int OffspringLength { get; }
        public abstract IChromosomeInt<TGene> GetOffspring(int index);
        public abstract void SetOffspring(int offspringIndex, IChromosomeInt<TGene> chromosome);

        public Generation(IChromosomeInt<TGene>[] chromosomes) => _chromosomes = chromosomes;

        protected void SortByFitness() => Array.Sort(_chromosomes, (a, b) => b.Fitness - a.Fitness);
        protected void SortByFitness(IChromosomeInt<TGene>[] chromosomeArray) 
            => Array.Sort(chromosomeArray, (a, b) => b.Fitness - a.Fitness);

        public void UpdateGenerationData() {
            GenerationCount++;
            OnStartNewGeneration();
        }

        protected abstract void OnStartNewGeneration();
    }
}

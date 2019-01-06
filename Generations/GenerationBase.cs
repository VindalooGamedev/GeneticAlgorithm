using System;

namespace GeneticAlgorithms {
    // Abstract class that defines the minimum requisites for each type of Generation.
    public abstract class GenerationBase<TGene> : IQueryableByTerminationCondition {
        protected IChromosomeInt<TGene>[] _chromosomes;

        public int GenCount { get; private set; } = 0;

        public abstract int MinFit { get; }
        public abstract int MaxFit { get; }

        public abstract int ParentsLength { get; }
        public abstract IChromosomeInt<TGene> GetParent(int index);
        public abstract void SetParent(int parentIndex, IChromosomeInt<TGene> chromosome);

        public abstract int OffspringLength { get; }
        public abstract IChromosomeInt<TGene> GetOffspring(int index);
        public abstract void SetOffspring(int offspringIndex, IChromosomeInt<TGene> chromosome);

        public GenerationBase(IChromosomeInt<TGene>[] chromosomes) => _chromosomes = chromosomes;

        protected void SortByFitness() => Array.Sort(_chromosomes, (a, b) => b.Fitness - a.Fitness);
        protected void SortByFitness(IChromosomeInt<TGene>[] chromosomeArray) 
            => Array.Sort(chromosomeArray, (a, b) => b.Fitness - a.Fitness);

        public void UpdateGenerationData() {
            GenCount++;
            OnStartNewGeneration();
        }

        protected abstract void OnStartNewGeneration();
    }
}

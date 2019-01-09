using System;

namespace GeneticAlgorithms {
    // Abstract class that defines the minimum requisites for each type of Generation.
    public abstract class GenBase<TGene> : IQueryableByTerminationCondition {
        protected IChromoInt<TGene>[] _chromo;

        public int GenCount { get; private set; } = 0;

        public abstract int MinFit { get; }
        public abstract int MaxFit { get; }

        public abstract int ParsLength { get; }
        public abstract IChromoInt<TGene> GetPar(int index);
        public abstract void SetPar(int parentIndex, IChromoInt<TGene> chromosome);

        public abstract int OffsLength { get; }
        public abstract IChromoInt<TGene> GetOff(int index);
        public abstract void SetOffs(int offspringIndex, IChromoInt<TGene> chromosome);

        public GenBase(IChromoInt<TGene>[] chromosomes) => _chromo = chromosomes;

        protected void SortByFit() => Array.Sort(_chromo, (a, b) => b.Fit - a.Fit);
        protected void SortByFitness(IChromoInt<TGene>[] chromosomeArray) 
            => Array.Sort(chromosomeArray, (a, b) => b.Fit - a.Fit);

        public void UpdateData() {
            GenCount++;
            OnStartNewGeneration();
        }

        protected abstract void OnStartNewGeneration();
    }
}

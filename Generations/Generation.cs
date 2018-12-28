namespace GeneticAlgorithms {
    // Abstract class that defines the minimum requisites for each type of Generation.
    public abstract class Generation<TGene> : IQueryableByTerminationCondition {
        protected IChromosomeInt<TGene>[] _chromosomes;
        public int GenerationCount { get; private set; } = 0;
        public abstract int OffspringLength { get; }
        public abstract int ParentsLength { get; }

        public abstract IChromosomeInt<TGene> GetParent(int index);
        public abstract IChromosomeInt<TGene> GetOffspring(int index);

        public Generation(IChromosomeInt<TGene>[] chromosomes) => _chromosomes = chromosomes;

        public void UpdateGenerationData() {
            GenerationCount++;
            OnStartNewGeneration();
        }

        protected abstract void OnStartNewGeneration();
    }
}

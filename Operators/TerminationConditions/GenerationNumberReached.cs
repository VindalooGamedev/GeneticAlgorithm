namespace GeneticAlgorithms {
    public struct GenerationNumberReachedInt<TGene> : ITerminationConditionInt<TGene> {
        private readonly int _maxGeneration;
        public GenerationNumberReachedInt(int max) => _maxGeneration = max;
        public bool IsMetIn (Generation<TGene> generation) => generation.GenerationCount >= _maxGeneration;
    }
}

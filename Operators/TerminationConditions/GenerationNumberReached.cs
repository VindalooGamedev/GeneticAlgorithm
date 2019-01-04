namespace GeneticAlgorithms {
    /// <summary>
    /// This termination condition evaluate where the number of 
    /// the generation reached is greater or equal than the max given to return true.
    /// </summary>
    /// <typeparam name="TGene"></typeparam>
    public struct GenerationNumberReachedInt<TGene> : ITerminationConditionInt<TGene> {
        private readonly int _maxGeneration;

        public GenerationNumberReachedInt(int max) => _maxGeneration = max;

        public bool IsMetIn (Generation<TGene> generation) => generation.GenerationCount >= _maxGeneration;
    }
}

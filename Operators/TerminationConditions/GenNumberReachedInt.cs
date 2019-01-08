namespace GeneticAlgorithms {
    /// <summary>
    /// This termination condition evaluate where the number of 
    /// the generation reached is greater or equal than the max given to return true.
    /// </summary>
    /// <typeparam name="TGene"></typeparam>
    public struct GenNumberReachedInt<TGene> : ITermCondInt<TGene> {
        private readonly int _maxGen;

        public GenNumberReachedInt(int max) => _maxGen = max;

        public bool IsMetIn (GenBase<TGene> gen) => gen.GenCount >= _maxGen;
    }
}

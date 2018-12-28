namespace GeneticAlgorithms {
    /// <summary>
    /// This Replacement Operator selects n Chromosomes that has the lowest fitness.
    /// The implementation of this operator is supported by the FitnessSortedGeneration method RemoveLasts(n).
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    class DeleteNLastsCleaner<TGene> : IReplacementInt {
        private FitnessSortedGeneration<TGene> _generation;
        private int _n;

        public DeleteNLastsCleaner(FitnessSortedGeneration<TGene> generation, int n) {
            _generation = generation;
            _n = n;
        }

        public void MakeRoom() => _generation.RemoveLasts(_n);
    }
}

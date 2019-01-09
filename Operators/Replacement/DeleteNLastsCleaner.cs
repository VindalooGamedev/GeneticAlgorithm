namespace GeneticAlgorithms {
    /// <summary>
    /// This Replacement Operator selects n Chromosomes that has the lowest fitness.
    /// The implementation of this operator is supported by the FitnessSortedGeneration method RemoveLasts(n).
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    class DeleteNLastsCleaner<TGene> : IReplInt {
        private Gen<TGene> _gen;
        private int _n;

        public DeleteNLastsCleaner(Gen<TGene> gen, int n) {
            _gen = gen;
            _n = n;
        }

        public void MakeRoom() => _gen.OffsLength = _n;
    }
}

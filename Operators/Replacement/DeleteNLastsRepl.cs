namespace GeneticAlgorithms {
    /// <summary>
    /// This Replacement Operator selects n Chromosomes that has the lowest fitness.
    /// The implementation of this operator is supported by the FitnessSortedGeneration method RemoveLasts(n).
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    class DeleteNLastsRepl<TGene> : IReplInt<TGene> {
        public Gen<TGene> Gen { get; set; }
        private int _n;

        public DeleteNLastsRepl(int n) => _n = n;

        public void MakeRoom() => Gen.OffsLength = _n;
    }
}

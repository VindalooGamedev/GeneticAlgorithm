namespace GeneticAlgorithms {
    // TODO: Facade Support.
    // TODO: Test if it works.
    public partial class SteStaExecutor<TGene> : ExecutorBase<TGene> {
        public ISteStaReplInt<TGene> _coordinator;
        public ISteaStaCrossInt<TGene> _breeder;

        protected override void PrepareToRun() {
            _coordinator.Gen = _gen;
            _breeder.Gen = _gen;
            _gen.OffsLength = 2;
        }

        protected override void Cycle() {
            (int, int) parentsSelected = _parentSelector.GetPairedParsOnce();
            _breeder.SimpleCrossWithMultipleSolutions(parentsSelected, _mutator);
            _coordinator.ReplaceComparingWithOffs(parentsSelected);
        }
    }
}

namespace GeneticAlgorithms {
    // TODO: Facade Support.
    // TODO: Test if it works.
    public partial class SteStaExecutor<TGene> : ExecutorBase<TGene> {
        public ISteStaReplInt<TGene> _coordinator;
        public ISteaStaCrossInt<TGene> _breeder;

        protected override void ExecuteRun() {
            _gen.OffsLength = 2;
            while (!_termCond.IsMetIn(_gen)) {
                (int, int) parentsSelected = _parentSelector.GetPairedParsOnce();
                _breeder.SimpleCrossWithMultipleSolutions(parentsSelected, _mutator);
                _coordinator.ReplaceComparingWithOffs(parentsSelected);
                _gen.UpdateData();
            }
        }
    }
}

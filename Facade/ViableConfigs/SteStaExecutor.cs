namespace GeneticAlgorithms {
    // TODO: Facade Support.
    // TODO: Test if it works.
    public partial class SteStaExecutor<TGene> {
        public Gen<TGene> _gen;
        public ITermCondInt<TGene> _termCond;
        public ISteStaReplInt<TGene> _coordinator;
        public ISteStaSelInt _parentSelector;
        public ISteaStaCrossInt<TGene> _breeder;
        public IMutInt<TGene> _mutator;
        public int _n;

        public SolutionInt<TGene> Run() {
            _gen.OffsLength = 2;
            while (!_termCond.IsMetIn(_gen)) {
                for (int i = 0; i < _n; i++) {
                    (int, int) parentsSelected = _parentSelector.GetPairedParsOnce();
                    _breeder.SimpleCrossWithMultipleSolutions(parentsSelected, _mutator);
                    _coordinator.ReplaceComparingWithOffs(parentsSelected);
                }
                _gen.UpdateData();
            }
            return new SolutionInt<TGene>(_gen);
        }
    }
}

namespace GeneticAlgorithms {
    // TODO: Facade Support.
    // TODO: Test if it works.
    public partial class SteadyStateExecutor<TGene> {
        public Generation<TGene> _generation;
        public ITerminationConditionInt<TGene> _terminationCondition;
        public ISteadyStateReplacementInt<TGene> _coordinator;
        public ISteadyStateSelectionInt _parentSelector;
        public ISteadyStateCrossoverInt<TGene> _breeder;
        public IMutationInt<TGene> _mutator;
        public int _n;

        public SolutionInt<TGene> Run() {
            while (!_terminationCondition.IsMetIn(_generation)) {
                for (int i = 0; i < _n; i++) {
                    (int, int) parentsSelected = _parentSelector.GetPairedParentsOnce();
                    _breeder.SimpleCrossWithMultipleSolutions(parentsSelected, _mutator);
                    _coordinator.ReplaceComparingWithOffsprings(parentsSelected);
                }
                _generation.UpdateGenerationData();
            }
            return new SolutionInt<TGene>(_generation);
        }
    }
}

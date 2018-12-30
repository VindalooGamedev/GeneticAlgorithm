namespace GeneticAlgorithms {
    // TODO: Facade Support.
    // TODO: Test if it works.
    public partial class SteadyStateExecutor<TGene> {
        private Generation<TGene> _generation;
        private ITerminationConditionInt<TGene> _terminationCondition;
        private ISteadyStateReplacementInt<TGene> _coordinator;
        private ISteadyStateSelectionInt _parentSelector;
        private ISteadyStateCrossoverInt<TGene> _breeder;
        private IMutationInt _mutator;
        private int _n;

        public SolutionInt<TGene> Run() {
            while (!_terminationCondition.IsMetIn(_generation)) {
                for (int i = 0; i < _n; i++) {
                    (int, int) parentsSelected = _parentSelector.GetPairedParentsOnce();
                    _breeder.SimpleCrossWithMultipleSolutions(parentsSelected);
                    _coordinator.ReplaceComparingWithOffsprings(parentsSelected);
                }
                _mutator.Mutate();
                _generation.UpdateGenerationData();
            }
            return new SolutionInt<TGene>(_generation);
        }
    }
}

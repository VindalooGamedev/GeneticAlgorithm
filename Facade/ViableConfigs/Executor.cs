namespace GeneticAlgorithms {
    public partial class Executor<TGene> {
        private FitnessSortedGeneration<TGene> _generation;
        private ITerminationConditionInt<TGene> _terminationCondition;
        private IReplacementInt _cleaner;
        private IFitnessSortedSelectionInt _parentSelector;
        private ICrossoverInt _breeder;
        private IMutationInt _mutator;

        public SolutionInt<TGene> Run() {
            while (!_terminationCondition.IsMetIn(_generation)) {
                _cleaner.MakeRoom();
                _breeder.Cross(_parentSelector.GetPairedParents());
                _mutator.Mutate();
                _generation.UpdateGenerationData();
            }
            return new SolutionInt<TGene>(_generation);
        }
    }
}

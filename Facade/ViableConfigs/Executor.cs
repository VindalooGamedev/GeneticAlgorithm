namespace GeneticAlgorithms {
    public partial class Executor<TGene> {
        public GenerationBase<TGene> _generation;
        public ITerminationConditionInt<TGene> _terminationCondition;
        public IReplacementInt _cleaner;
        public ISelectionInt _parentSelector;
        public ICrossoverInt<TGene> _breeder;
        public IMutationInt<TGene> _mutator;

        public SolutionInt<TGene> Run() {
            while (!_terminationCondition.IsMetIn(_generation)) {
                _cleaner.MakeRoom();
                _breeder.MultipleCross(_parentSelector.GetPairedParentsForEveryOffspring(), _mutator);
                _generation.UpdateGenerationData();
            }
            return new SolutionInt<TGene>(_generation);
        }
    }
}

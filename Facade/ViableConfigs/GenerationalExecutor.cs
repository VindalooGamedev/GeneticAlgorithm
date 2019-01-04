namespace GeneticAlgorithms {
    public partial class GenerationalExecutor<TGene> {
        public Generation<TGene> _generation;
        public ITerminationConditionInt<TGene> _terminationCondition;
        public ISelectionInt _parentSelector;
        public ICrossoverInt<TGene> _breeder;
        public IMutationInt<TGene> _mutator;

        public SolutionInt<TGene> Run() {
            while (!_terminationCondition.IsMetIn(_generation)) {
                _breeder.MultipleCross(_parentSelector.GetPairedParentsForEveryOffspring(), _mutator);
                _generation.UpdateGenerationData();
            }
            return new SolutionInt<TGene>(_generation);
        }
    }
}

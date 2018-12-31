namespace GeneticAlgorithms {
    /// <summary>
    /// This Selection Operator selects randomly k parents and choose the one with higher fitness.
    /// This operator uses FitnessSortedGeneration so to select the higher 
    /// fitness just need to select the lower index of parent selected.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public class TournamentSelector<TGene> : SelectorBase<FitnessSortedGeneration<TGene>, TGene> {
        private int _k, 
                    _parentsAmount;

        public TournamentSelector(FitnessSortedGeneration<TGene> generation, int k) {
            _generation = generation;
            _k = k;
        }

        protected override void PrepareData() => _parentsAmount = _generation.ParentsLength;

        protected override int GetFirstParent() => ParentSelected(_parentsAmount, _k);

        protected override int GetSecondParent(int otherParent) {
            int parent = ParentSelected(_parentsAmount - 1, _k);
            return (parent >= otherParent) ? parent + 1 : parent;
        }

        private int ParentSelected(int parentamount, int tries) =>
            Randomizer.FilteredByConditionBestEffortRandom(_parentsAmount, _k, (int a, int b) => a < b);
    }
}

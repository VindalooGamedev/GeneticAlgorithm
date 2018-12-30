namespace GeneticAlgorithms {
    /// <summary>
    /// This Selection Operator selects randomly k parents and choose the one with higher fitness.
    /// This operator uses FitnessSortedGeneration so to select the higher 
    /// fitness just need to select the lower index of parent selected.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public class TournamentSelector<TGene> : ISelectionInt, ISteadyStateSelectionInt {
        private FitnessSortedGeneration<TGene> _generation;
        private int _k, 
                    _parentsAmount;

        public TournamentSelector(FitnessSortedGeneration<TGene> generation, int k) {
            _generation = generation;
            _k = k;
        }

        // Al ejecutar esto tiene que haber más de 1 offspring slot y k debe ser menor que la cantidad de parents
        public (int, int)[] GetPairedParentsForEveryOffspring() {
            // prepare space and data to manage to choose pairs
            (int, int)[] pairedParents = new(int, int)[_generation.OffspringLength];
            PrepareData();

            // Choose all pairs
            for (int i = 0; i < pairedParents.Length; i++) {
                pairedParents[i].Item1 = GetFirstParent();
                pairedParents[i].Item2 = GetSecondParent(pairedParents[i].Item1);
            }
            return pairedParents;
        }

        private void PrepareData() => _parentsAmount = _generation.ParentsLength;

        public (int, int) GetPairedParentsOnce() {
            PrepareData();
            int firstParent = GetFirstParent();
            return (firstParent, GetSecondParent(firstParent));
        }

        private int GetFirstParent() => ParentSelected(_parentsAmount, _k);

        private int GetSecondParent(int otherParent) {
            int parent = ParentSelected(_parentsAmount - 1, _k);
            return (parent >= otherParent) ? parent + 1 : parent;
        }

        private int ParentSelected(int parentamount, int tries) =>
            Randomizer.FilteredByConditionBestEffortRandom(_parentsAmount, _k, (int a, int b) => a < b);
    }
}

namespace GeneticAlgorithms {
    // TODO: It needs to be tested.
    public partial class RankSelector<TGene> : IFitnessSortedSelectionInt {
        private FitnessSortedGeneration<TGene> _generation;
        private int _n, _nsum;

        public RankSelector(FitnessSortedGeneration<TGene> generation) => _generation = generation;

        public (int, int)[] GetPairedParents() {
            // Preparing the scope.
            (int, int)[] pairedParents = new(int, int)[_generation.OffspringLength];
            _n = _generation.ParentsLength;

            // Gauss formula (Sum of n first numbers).
            _nsum = _n * (_n + 1) / 2;
            // nsum Edited for random usage purposes.
            _nsum++;

            // Choose all pairs.
            for (var i = 0; i < pairedParents.Length; i++) {
                pairedParents[i].Item1 = GetFirstParent();
                pairedParents[i].Item2 = GetSecondParent(pairedParents[i].Item1);
            }
            return pairedParents;
        }

        private int GetFirstParent() {
            int position = Randomizer.Next(1, _nsum);
            int chromosome = -1;
            int sizeToRemove = _n;
            while (position > 0) {
                chromosome++;
                position -= sizeToRemove;
                sizeToRemove--;
            }
            return chromosome;
        }

        private int GetSecondParent(int otherParent) {
            int position = Randomizer.Next(1, _nsum - (_nsum - 1 - otherParent));
            int chromosome = -1;
            int sizeToRemove = _n;
            while (position > 0) {
                chromosome++;
                if (chromosome == otherParent) {
                    chromosome++;
                    sizeToRemove--;
                }
                position -= sizeToRemove;
                sizeToRemove--;
            }
            return chromosome;
        }
    }
}

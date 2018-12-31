namespace GeneticAlgorithms {
    // TODO: It needs to be tested.
    /// <summary>
    /// This Selection Operator weights chance to be selected for each chromosome
    /// by sorting them fitness desc and giving a fixed step of more value for those with higher fitness.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public partial class RankSelector<TGene> : SelectorBase<FitnessSortedGeneration<TGene>, TGene> {
        private int _n, _nsum;

        public RankSelector(FitnessSortedGeneration<TGene> generation) => _generation = generation;

        protected override void PrepareData() {
            _n = _generation.ParentsLength;

            // Gauss formula (Sum of n first numbers).
            _nsum = _n * (_n + 1) / 2;
            // nsum Edited for random usage purposes.
            _nsum++;
        }

        protected override int GetFirstParent() {
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

        protected override int GetSecondParent(int otherParent) {
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

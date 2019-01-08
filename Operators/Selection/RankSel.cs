namespace GeneticAlgorithms {
    // TODO: It needs to be tested.
    /// <summary>
    /// This Selection Operator weights chance to be selected for each chromosome
    /// by sorting them fitness desc and giving a fixed step of more value for those with higher fitness.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public partial class RankSel<TGene> : SelBase<FitSortGen<TGene>, TGene> {
        private int _n, 
                    _nsum;

        public RankSel(FitSortGen<TGene> gen) => _gen = gen;

        protected override void PrepareData() {
            _n = _gen.ParsLength;

            // Gauss formula (Sum of n first numbers).
            _nsum = _n * (_n + 1) / 2;
            // nsum Edited for random usage purposes.
            _nsum++;
        }

        protected override int GetFirstPar() {
            int pos = Randomizer.Next(1, _nsum);
            int chromo = -1;
            int sizeToRemove = _n;
            while (pos > 0) {
                chromo++;
                pos -= sizeToRemove;
                sizeToRemove--;
            }
            return chromo;
        }

        protected override int GetSecondPar(int otherPar) {
            int pos = Randomizer.Next(1, _nsum - (_nsum - 1 - otherPar));
            int chromo = -1;
            int sizeToRemove = _n;
            while (pos > 0) {
                chromo++;
                if (chromo == otherPar) {
                    chromo++;
                    sizeToRemove--;
                }
                pos -= sizeToRemove;
                sizeToRemove--;
            }
            return chromo;
        }
    }
}

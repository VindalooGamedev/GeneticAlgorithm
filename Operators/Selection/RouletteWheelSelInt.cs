namespace GeneticAlgorithms {
    // TODO: It needs to be tested.
    /// <summary>
    /// This Selection Operator weights chance to be selected for each chromosome fitness,
    /// the higher the fitness the higher the chance to be selected to be a parent.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public partial class RouletteWheelSelInt<TGene> : SelBase<GenBase<TGene>, TGene> {
        private int _fitsSum;

        public RouletteWheelSelInt(GenBase<TGene> gen) => _gen = gen;
        
        protected override void PrepareData() {
            _fitsSum = 0;
            for (int i = 0; i < _gen.ParsLength; i++) {
                _fitsSum += _gen.GetPar(i).Fit;
            }
        }

        protected override int GetFirstPar() {
            int pos = Randomizer.Next(0, _fitsSum);
            int chromo = -1;
            do {
                chromo++;
                pos -= _gen.GetPar(chromo).Fit;
            } while (pos > 0);
            return chromo;
        }

        protected override int GetSecondPar(int otherParent) {
            int pos = Randomizer.Next(0, _fitsSum - (_gen.GetPar(otherParent).Fit));
            int chromo = -1;
            do {
                chromo++;
                if (chromo == otherParent) {
                    chromo++;
                }
                pos -= _gen.GetPar(chromo).Fit;
            } while (pos > 0);
            return chromo;
        }
    }
}

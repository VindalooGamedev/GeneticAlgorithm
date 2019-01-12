namespace GeneticAlgorithms {
    // TODO: It needs to be tested.
    /// <summary>
    /// This Selection Operator weights chance to be selected for each chromosome fitness,
    /// the higher the fitness the higher the chance to be selected to be a parent.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public partial class RouletteWheelSelInt<TGene> : SelBase<TGene> {
        private int _fitsSum;
        
        protected override void PrepareData() {
            _fitsSum = 0;
            for (int i = 0; i < Gen.ParsLength; i++) {
                _fitsSum += Gen.GetPar(i).Fit;
            }
        }

        protected override int GetFirstPar() {
            int pos = Randomizer.Next(0, _fitsSum);
            int chromo = -1;
            do {
                chromo++;
                pos -= Gen.GetPar(chromo).Fit;
            } while (pos > 0);
            return chromo;
        }

        protected override int GetSecondPar(int otherPar) {
            int pos = Randomizer.Next(0, _fitsSum - (Gen.GetPar(otherPar).Fit));
            int chromo = -1;
            do {
                chromo++;
                if (chromo == otherPar) {
                    chromo++;
                }
                pos -= Gen.GetPar(chromo).Fit;
            } while (pos > 0);
            return chromo;
        }
    }
}

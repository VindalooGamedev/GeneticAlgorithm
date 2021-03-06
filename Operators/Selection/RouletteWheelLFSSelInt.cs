﻿namespace GeneticAlgorithms {
    // TODO: It needs to be tested.
    /// <summary>
    /// This Selection Operator weights chance to be selected for each chromosome fitness,
    /// the higher the fitness the higher the chance to be selected to be a parent.
    /// This version gets the statistics to center the focus on higher values, it reduces the problem
    /// where all values are high and there is almost no weight on being higher.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public partial class RouletteWheelLFSSelInt<TGene> : SelBase<TGene> {
        private int[] _fits;
        private int _fitsSum;
        
        protected override void PrepareData() {
            int initialSum = 0;
            for (int i = 0; i < Gen.ParsLength; i++) {
                initialSum += Gen.GetPar(i).Fit;
            }

            int mean = initialSum / Gen.ParsLength;
            int min = mean - (Gen.MaxFit - mean);


            _fits = new int[Gen.ParsLength];
            for (int i = 0; i < Gen.ParsLength; i++) {
                _fits[i] = Gen.GetPar(i).Fit - min;
                if (_fits[i] < 0) {
                    _fits[i] = 0;
                }
            }

            _fitsSum = 0;
            for (int i = 0; i < _fits.Length; i++) {
                _fitsSum += _fits[i];
            }
        }

        protected override int GetFirstPar() {
            int pos = Randomizer.Next(0, _fitsSum);
            int chromo = -1;
            do {
                chromo++;
                pos -= _fits[chromo];
            } while (pos > 0);
            return chromo;
        }

        protected override int GetSecondPar(int otherParent) {
            int pos = Randomizer.Next(0, _fitsSum - (_fits[otherParent]));
            int chromo = -1;
            do {
                chromo++;
                if (chromo == otherParent) {
                    chromo++;
                }
                pos -= _fits[chromo];
            } while (pos > 0);
            return chromo;
        }
    }
}

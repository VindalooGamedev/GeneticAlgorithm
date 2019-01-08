﻿namespace GeneticAlgorithms {
    /// <summary>
    /// This Selection Operator selects randomly k parents and choose the one with higher fitness.
    /// This operator uses FitnessSortedGeneration so to select the higher 
    /// fitness just need to select the lower index of parent selected.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public class TournamentSel<TGene> : SelBase<FitSortGen<TGene>, TGene> {
        private int _k, 
                    _parsAmount;

        public TournamentSel(FitSortGen<TGene> gen, int k) {
            _gen = gen;
            _k = k;
        }

        protected override void PrepareData() => _parsAmount = _gen.ParsLength;

        protected override int GetFirstPar() => ParSelected(_parsAmount, _k);

        protected override int GetSecondPar(int otherPar) {
            int par = ParSelected(_parsAmount - 1, _k);
            return (par >= otherPar) ? par + 1 : par;
        }

        private int ParSelected(int parentamount, int tries) =>
            Randomizer.FilteredByCondBestEffortRandom(_parsAmount, _k, (int a, int b) => a < b);
    }
}

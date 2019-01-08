using System;

namespace GeneticAlgorithms {
    /// <summary>
    /// This class adds a feature of chromosomes sorted by Fitness desc.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public class FitSortGen<TGene> : GenBase<TGene> {
        private int _offsSlots;

        public override int OffsLength => _offsSlots;
        public override int ParsLength => _chromo.Length - _offsSlots;

        public override int MinFit => _chromo[ParsLength - 1].Fit;
        public override int MaxFit => _chromo[0].Fit;

        // Constructor
        public FitSortGen(IChromoInt<TGene>[] chromos) : base(chromos)
            => SortByFit();

        public override IChromoInt<TGene> GetPar(int i) => _chromo[i];

        public override void SetPar(int index, IChromoInt<TGene> chromosome)
            => _chromo[index] = chromosome;

        public override IChromoInt<TGene> GetOff(int i)
            => _chromo[_chromo.Length - _offsSlots + i];

        public override void SetOffs(int i, IChromoInt<TGene> chromo)
            => _chromo[_chromo.Length - _offsSlots + i] = chromo;

        // Function to make room for offsprings.
        // This functions assign to removable parents those last n parents with less fitness
        public void RemoveLasts(int n) {
            SortByFit();
            _offsSlots = n;
        }

        protected override void OnStartNewGeneration() => SortByFit();
    }
}

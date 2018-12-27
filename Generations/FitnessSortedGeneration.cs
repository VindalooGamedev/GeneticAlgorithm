using System;

namespace GeneticAlgorithms {
    public class FitnessSortedGeneration<TGene> : Generation<TGene> {
        private int _offspringSlots;

        public override int OffspringLength => _offspringSlots;
        public override int ParentsLength => _chromosomes.Length - _offspringSlots;

        public FitnessSortedGeneration(IChromosomeInt<TGene>[] chromosomes) : base(chromosomes) => SortByFitness();

        public override IChromosomeInt<TGene> GetParent(int index) => _chromosomes[index];

        public override IChromosomeInt<TGene> GetOffspring(int index)
            => _chromosomes[_chromosomes.Length - _offspringSlots + index];


        private void SortByFitness() => Array.Sort(_chromosomes, (a, b) => b.Fitness - a.Fitness);

        public void RemoveLasts(int n) {
            SortByFitness();
            _offspringSlots = n;
        }

        protected override void OnStartNewGeneration() => SortByFitness();
    }
}

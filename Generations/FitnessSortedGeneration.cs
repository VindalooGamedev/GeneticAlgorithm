using System;

namespace GeneticAlgorithms {
    /// <summary>
    /// This class adds a feature of chromosomes sorted by Fitness desc.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public class FitnessSortedGeneration<TGene> : Generation<TGene> {
        private int _offspringSlots;

        public override int OffspringLength => _offspringSlots;
        public override int ParentsLength => _chromosomes.Length - _offspringSlots;

        public override int MinimumFitness => _chromosomes[ParentsLength - 1].Fitness;
        public override int MaximumFitness => _chromosomes[0].Fitness;

        // Constructor
        public FitnessSortedGeneration(IChromosomeInt<TGene>[] chromosomes) : base(chromosomes)
            => SortByFitness();

        public override IChromosomeInt<TGene> GetParent(int index) => _chromosomes[index];

        public override void SetParent(int index, IChromosomeInt<TGene> chromosome)
            => _chromosomes[index] = chromosome;

        public override IChromosomeInt<TGene> GetOffspring(int index)
            => _chromosomes[_chromosomes.Length - _offspringSlots + index];

        public override void SetOffspring(int index, IChromosomeInt<TGene> chromosome)
            => _chromosomes[_chromosomes.Length - _offspringSlots + index] = chromosome;

        // Function to make room for offsprings.
        // This functions assign to removable parents those last n parents with less fitness
        public void RemoveLasts(int n) {
            SortByFitness();
            _offspringSlots = n;
        }

        protected override void OnStartNewGeneration() => SortByFitness();
    }
}

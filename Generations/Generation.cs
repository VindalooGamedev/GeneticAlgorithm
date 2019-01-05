using System;
namespace GeneticAlgorithms {
    public class Generation<TGene> : GenerationBase<TGene> {
        [Flags]
        public enum Requirements : short {
            None = 0,
            FitnessSorted = 1,
            VirtuallyUnsorted = 2,
            ChromosomeVirtuallySplitted = 4,
        };

        private int _offspringLength;
        public override int OffspringLength => _offspringLength;

        private int _parentsLength;
        public override int ParentsLength => _parentsLength;

        private int _minimumFitness;
        public override int MinimumFitness => _minimumFitness;

        private int _maximumFitness;
        public override int MaximumFitness => _maximumFitness;

        public Generation(IChromosomeInt<TGene>[] chromosomes, Requirements requirements) 
            : base(chromosomes) {

        }

        public override IChromosomeInt<TGene> GetOffspring(int index) {
            throw new System.NotImplementedException();
        }

        public override IChromosomeInt<TGene> GetParent(int index) {
            throw new System.NotImplementedException();
        }

        public override void SetOffspring(int offspringIndex, IChromosomeInt<TGene> chromosome) {
            throw new System.NotImplementedException();
        }

        public override void SetParent(int parentIndex, IChromosomeInt<TGene> chromosome) {
            throw new System.NotImplementedException();
        }

        protected override void OnStartNewGeneration() {
            throw new System.NotImplementedException();
        }
    }
}

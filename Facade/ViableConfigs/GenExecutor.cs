namespace GeneticAlgorithms {
    public partial class GenExecutor<TGene> : ExecutorBase<TGene> {
        public ICrossInt<TGene> _breeder;

        protected override void Cycle() 
            => _breeder.MultipleCross(_parentSelector.GetPairedParsForEveryOff(), _mutator);

        protected override void PrepareToRun() => _breeder.Gen = _gen;
    }
}

namespace GeneticAlgorithms {
    public partial class Executor<TGene> : ExecutorBase<TGene> {
        public IReplInt<TGene> _cleaner;
        public ICrossInt<TGene> _breeder;

        protected override void PrepareToRun() {
            _cleaner.Gen = _gen;
            _breeder.Gen = _gen;
        }

        protected override void Cycle() {
            _cleaner.MakeRoom();
            _breeder.MultipleCross(_parentSelector.GetPairedParsForEveryOff(), _mutator);
        }
    }
}

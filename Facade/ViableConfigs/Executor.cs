namespace GeneticAlgorithms {
    public partial class Executor<TGene> : ExecutorBase<TGene> {
        public IReplInt<TGene> _cleaner;
        public ICrossInt<TGene> _breeder;

        protected override void ExecuteRun() {
            _cleaner.Gen = _gen;
            _breeder.Gen = _gen;
            while (!_termCond.IsMetIn(_gen)) {
                _cleaner.MakeRoom();
                _breeder.MultipleCross(_parentSelector.GetPairedParsForEveryOff(), _mutator);
                _gen.UpdateData();
            }
        }
    }
}

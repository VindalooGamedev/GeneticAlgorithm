using System;

namespace GeneticAlgorithms {
    public partial class GenExecutor<TGene> : ExecutorBase<TGene> {
        public ICrossInt<TGene> _breeder;

        protected override void ExecuteRun() {
            _breeder.Gen = _gen;
            while (!_termCond.IsMetIn(_gen)) {
                _breeder.MultipleCross(_parentSelector.GetPairedParsForEveryOff(), _mutator);
                _gen.UpdateData();
            }
        }
    }
}

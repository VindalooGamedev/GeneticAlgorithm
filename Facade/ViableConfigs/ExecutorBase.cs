using System;

namespace GeneticAlgorithms {
    public abstract class ExecutorBase<TGene> {
        public Gen<TGene> _gen;
        public SelBase<TGene> _parentSelector;
        public ITermCondInt<TGene> _termCond;
        public IMutInt<TGene> _mutator;

        public Action RunEndedCallback { get; set; }

        public void SetGeneration(Gen<TGene> gen) => _gen = gen;

        public void Run() {
            _parentSelector.Gen = _gen;
            PrepareToRun();
            while (!_termCond.IsMetIn(_gen)) {
                Cycle();
                _gen.UpdateData();
            }
            RunEndedCallback?.Invoke();
        }

        protected abstract void PrepareToRun();
        protected abstract void Cycle();
    }
}

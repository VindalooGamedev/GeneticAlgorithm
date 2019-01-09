namespace GeneticAlgorithms {
    public partial class Executor<TGene> {
        public Gen<TGene> _gen;
        public ITermCondInt<TGene> _termCond;
        public IReplInt _cleaner;
        public ISelInt _parentSelector;
        public ICrossInt<TGene> _breeder;
        public IMutInt<TGene> _mutator;

        public SolutionInt<TGene> Run() {
            while (!_termCond.IsMetIn(_gen)) {
                _cleaner.MakeRoom();
                _breeder.MultipleCross(_parentSelector.GetPairedParsForEveryOff(), _mutator);
                _gen.UpdateData();
            }
            return new SolutionInt<TGene>(_gen);
        }
    }
}

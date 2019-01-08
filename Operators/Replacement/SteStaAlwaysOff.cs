namespace GeneticAlgorithms {
    public class SteStaAlwaysOff<TGene> : ISteStaReplInt<TGene> {
        private GenBase<TGene> _gen;

        public SteStaAlwaysOff(GenBase<TGene> gen)
            => _gen = gen;

        public void ReplaceComparingWithOffs((int, int) pars) {
            IChromoInt<TGene>[] auxPars = {
                _gen.GetPar(pars.Item1),
                _gen.GetPar(pars.Item2),
            };

            _gen.SetPar(pars.Item1, _gen.GetOff(0));
            _gen.SetPar(pars.Item2, _gen.GetOff(1));
            _gen.SetOffs(0, auxPars[0]);
            _gen.SetOffs(1, auxPars[1]);
        }
    }

}

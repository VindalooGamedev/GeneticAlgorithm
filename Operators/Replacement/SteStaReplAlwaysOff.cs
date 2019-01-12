namespace GeneticAlgorithms {
    public class SteStaReplAlwaysOff<TGene> : ISteStaReplInt<TGene> {
        private Gen<TGene> _gen;

        public SteStaReplAlwaysOff(Gen<TGene> gen) => _gen = gen;

        public void ReplaceComparingWithOffs((int, int) pars) {
            _gen.Switch(pars.Item1, 0);
            _gen.Switch(pars.Item2, 1);
        }
    }
}

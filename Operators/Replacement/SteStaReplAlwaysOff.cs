namespace GeneticAlgorithms {
    public class SteStaReplAlwaysOff<TGene> : ISteStaReplInt<TGene> {
        public Gen<TGene> Gen { get; set; }

        public void ReplaceComparingWithOffs((int, int) pars) {
            Gen.Switch(pars.Item1, 0);
            Gen.Switch(pars.Item2, 1);
        }
    }
}

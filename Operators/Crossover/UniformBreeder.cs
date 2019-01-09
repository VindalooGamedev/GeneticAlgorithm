namespace GeneticAlgorithms {
    /// <summary>
    /// This Crossover Operator do the crossover of each locus 
    /// selecting one of the parents gene at 50% of chance each.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public class UniformBreeder<TGene> : ICrossInt<TGene>, ISteaStaCrossInt<TGene> {
        private Gen<TGene> _gen;

        public UniformBreeder(Gen<TGene> gen) => _gen = gen;

        public void MultipleCross((int, int)[] pars, IMutInt<TGene> mutator) {
            IChromoInt<TGene> par1,
                              par2,
                              off;

            for (int i = 0; i < _gen.OffsLength; i++) {
                par1 = _gen.GetPar(pars[i].Item1);
                par2 = _gen.GetPar(pars[i].Item2);
                off = _gen.GetOff(i);

                for (int j = 0; j < off.Length; j++) {
                    off[j] = (Randomizer.Next(2) == 0) ? par1[j] : par2[j];
                }

                mutator.Mutate(off);
            }
        }

        public void SimpleCrossWithMultipleSolutions((int, int) pars, IMutInt<TGene> mutator) {
            IChromoInt<TGene> par1 = _gen.GetPar(pars.Item1);
            IChromoInt<TGene> par2 = _gen.GetPar(pars.Item2);
            IChromoInt<TGene> off1 = _gen.GetOff(0);
            IChromoInt<TGene> off2 = _gen.GetOff(1);

            for (int j = 0; j < off1.Length; j++) {
                if (Randomizer.Next(2) == 0) {
                    off1[j] = par1[j];
                    off2[j] = par2[j];
                }
                else {
                    off1[j] = par2[j];
                    off2[j] = par1[j];
                }
            }

            mutator.Mutate(off1);
            mutator.Mutate(off2);
        }
    }
}

namespace GeneticAlgorithms {
    class OnePointBreeder<TGene> : ICrossInt<TGene>, ISteaStaCrossInt<TGene> {
        private GenBase<TGene> _gen;

        public OnePointBreeder(GenBase<TGene> gen) => _gen = gen;

        public void MultipleCross((int, int)[] pars, IMutInt<TGene> mutator) {
            IChromoInt<TGene> par1,
                              par2,
                              off;

            for (int i = 0; i < _gen.OffsLength; i++) {
                par1 = _gen.GetPar(pars[i].Item1);
                par2 = _gen.GetPar(pars[i].Item2);
                off = _gen.GetOff(i);

                int crossPoint = Randomizer.Next(off.Length - 1);

                for (int j = 0; j <= crossPoint; j++) {
                    off[j] = par1[j];
                }

                for (int j = crossPoint; j < off.Length; j++) {
                    off[j] = par2[j];
                }

                mutator.Mutate(off);
            }
        }

        public void SimpleCrossWithMultipleSolutions((int, int) parents, IMutInt<TGene> mutator) {
            IChromoInt<TGene> par1 = _gen.GetPar(parents.Item1);
            IChromoInt<TGene> par2 = _gen.GetPar(parents.Item2);
            IChromoInt<TGene> off1 = _gen.GetOff(0);
            IChromoInt<TGene> off2 = _gen.GetOff(1);

            int crossPoint = Randomizer.Next(off1.Length - 1);

            for (int j = 0; j <= crossPoint; j++) {
                off1[j] = par1[j];
                off2[j] = par2[j];
            }

            for (int j = crossPoint; j < off1.Length; j++) {
                off1[j] = par2[j];
                off2[j] = par1[j];
            }

            mutator.Mutate(off1);
            mutator.Mutate(off2);
        }
    }
}

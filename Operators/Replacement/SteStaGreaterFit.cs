using System;

namespace GeneticAlgorithms {
    public class SteStaGreaterFit<TGene> : ISteStaReplInt<TGene> {
        private GenBase<TGene> _gen;

        public SteStaGreaterFit(GenBase<TGene> gen) 
            => _gen = gen;

        public void ReplaceComparingWithOffs((int, int) pars) {
            IChromoInt<TGene>[] parsAndOffs = {
                _gen.GetPar(pars.Item1),
                _gen.GetPar(pars.Item2),
                _gen.GetOff(0),
                _gen.GetOff(1)
            };

            Array.Sort(parsAndOffs, (a, b) => b.Fit - a.Fit);

            _gen.SetPar(pars.Item1, parsAndOffs[0]);
            _gen.SetPar(pars.Item2, parsAndOffs[1]);
            _gen.SetOffs(0, parsAndOffs[2]);
            _gen.SetOffs(1, parsAndOffs[3]);
        }
    }
}

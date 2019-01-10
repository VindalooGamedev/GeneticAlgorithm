using System;

namespace GeneticAlgorithms {
    public class SteStaGreaterFit<TGene> : ISteStaReplInt<TGene> {
        private Gen<TGene> _gen;

        public SteStaGreaterFit(Gen<TGene> gen) => _gen = gen;

        public void ReplaceComparingWithOffs((int, int) pars) {
            // Catch all chromosomes sorted by offsprings after parents
            IChromoInt<TGene>[] parsAndOffs = {
                _gen.GetPar(pars.Item1),
                _gen.GetPar(pars.Item2),
                _gen.GetOff(0),
                _gen.GetOff(1)
            };

            // Dereference chromosomes with indexes to maintain their position
            int[] indexes = new int[parsAndOffs.Length];
            for (int i = 0; i < parsAndOffs.Length; i++) {
                indexes[i] = i;
            }

            // Sort indexes by chromosome fitnesses
            Array.Sort(indexes, (a, b) => parsAndOffs[b].Fit - parsAndOffs[a].Fit);

            // Function to know if they are parents through their original position
            // Func<int, bool> IsPar = (int i) => indexes[i] < 2; // Alternative C#6
            bool IsPar(int i) => indexes[i] < 2;
            
            
            // If thos at lastest position are both parents then change both and return
            if ((IsPar(2)) && (IsPar(3))) {
                _gen.Switch(pars.Item1, 0);
                _gen.Switch(pars.Item2, 1);
                return;
            }

            // if the one in the third position is parent then change it and return
            if (IsPar(2)){
                _gen.Switch((IsPar(0)) ? indexes[0] : indexes[1], indexes[2]);
                return;
            }

            // if the one in the fourth position is parent then change it and return
            if (IsPar(3)) {
                _gen.Switch((IsPar(0)) ? indexes[0] : indexes[1], indexes[3]);
                return;
            }
        }
    }
}

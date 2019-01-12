using System;

namespace GeneticAlgorithms {
    public class SteStaReplGreaterFit<TGene> : ISteStaReplInt<TGene> {
        public Gen<TGene> Gen { get; set; }

        public void ReplaceComparingWithOffs((int, int) pars) {
            // Catch all chromosomes sorted by offsprings after parents
            IChromoInt<TGene>[] parsAndOffs = {
                Gen.GetPar(pars.Item1),
                Gen.GetPar(pars.Item2),
                Gen.GetOff(0),
                Gen.GetOff(1)
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
                Gen.Switch(pars.Item1, 0);
                Gen.Switch(pars.Item2, 1);
                return;
            }

            // if the one in the third position is parent then change it and return
            if (IsPar(2)) {
                Gen.Switch((IsPar(0)) ? indexes[0] : indexes[1], indexes[2]);
                return;
            }

            // if the one in the fourth position is parent then change it and return
            if (IsPar(3)) {
                Gen.Switch((IsPar(0)) ? indexes[0] : indexes[1], indexes[3]);
                return;
            }
        }
    }
}

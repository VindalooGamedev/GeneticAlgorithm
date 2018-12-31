using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithms {
    public abstract class SelectorBase<TGeneration, TGene> : ISelectionInt, ISteadyStateSelectionInt
        where TGeneration : Generation<TGene> {
        protected TGeneration _generation;

        public (int, int)[] GetPairedParentsForEveryOffspring() {
            (int, int)[] pairedParents = new(int, int)[_generation.OffspringLength];
            PrepareData();

            // Choose all pairs.
            for (var i = 0; i < pairedParents.Length; i++) {
                pairedParents[i].Item1 = GetFirstParent();
                pairedParents[i].Item2 = GetSecondParent(pairedParents[i].Item1);
            }
            return pairedParents;
        }

        protected abstract void PrepareData();
        protected abstract int GetFirstParent();
        protected abstract int GetSecondParent(int item1);

        public (int, int) GetPairedParentsOnce() {
            PrepareData();
            int firstParent = GetFirstParent();
            return (firstParent, GetSecondParent(firstParent));
        }
    }
}

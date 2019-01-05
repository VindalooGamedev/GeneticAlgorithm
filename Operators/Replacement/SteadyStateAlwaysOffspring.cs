using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithms.src.Operators.Replacement {
    public class SteadyStateAlwaysOffspring<TGene> : ISteadyStateReplacementInt<TGene> {
        private GenerationBase<TGene> _generation;

        public SteadyStateAlwaysOffspring(GenerationBase<TGene> generation) 
            => _generation = generation;

        public void ReplaceComparingWithOffsprings((int, int) parents) {
            IChromosomeInt<TGene>[] auxParents = {
                _generation.GetParent(parents.Item1),
                _generation.GetParent(parents.Item2),
            };
            
            _generation.SetParent(parents.Item1, _generation.GetOffspring(0));
            _generation.SetParent(parents.Item2, _generation.GetOffspring(1));
            _generation.SetOffspring(0, auxParents[0]);
            _generation.SetOffspring(1, auxParents[1]);
        }
    }

}

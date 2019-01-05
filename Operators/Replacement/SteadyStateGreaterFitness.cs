using System;

namespace GeneticAlgorithms {
    public class SteadyStateGreaterFitness<TGene> : ISteadyStateReplacementInt<TGene> {
        private GenerationBase<TGene> _generation;

        public SteadyStateGreaterFitness(GenerationBase<TGene> generation) 
            => _generation = generation;

        public void ReplaceComparingWithOffsprings((int, int) parents) {
            IChromosomeInt<TGene>[] parentsAndOffsprings = {
                _generation.GetParent(parents.Item1),
                _generation.GetParent(parents.Item2),
                _generation.GetOffspring(0),
                _generation.GetOffspring(1)
            };

            Array.Sort(parentsAndOffsprings, (a, b) => b.Fitness - a.Fitness);

            _generation.SetParent(parents.Item1, parentsAndOffsprings[0]);
            _generation.SetParent(parents.Item2, parentsAndOffsprings[1]);
            _generation.SetOffspring(0, parentsAndOffsprings[2]);
            _generation.SetOffspring(1, parentsAndOffsprings[3]);
        }
    }
}

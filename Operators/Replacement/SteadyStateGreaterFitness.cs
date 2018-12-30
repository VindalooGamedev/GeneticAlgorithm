using System;

namespace GeneticAlgorithms {
    public class SteadyStateGreaterFitness<TGene> : ISteadyStateReplacementInt<TGene> {
        private Generation<TGene> _generation;

        public SteadyStateGreaterFitness(Generation<TGene> generation) => _generation = generation;

        public void ReplaceComparingWithOffsprings((int, int) parents) {
            IChromosomeInt<TGene>[] _parentsAndOffsprings = {
                _generation.GetParent(parents.Item1),
                _generation.GetParent(parents.Item2),
                _generation.GetOffspring(0),
                _generation.GetOffspring(1)
            };

            Array.Sort(_parentsAndOffsprings, (a, b) => a.Fitness - b.Fitness);

            _generation.SetParent(parents.Item1, _parentsAndOffsprings[0]);
            _generation.SetParent(parents.Item2, _parentsAndOffsprings[1]);
            _generation.SetOffspring(0, _parentsAndOffsprings[2]);
            _generation.SetOffspring(1, _parentsAndOffsprings[3]);
        }
    }
}

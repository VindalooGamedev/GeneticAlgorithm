namespace GeneticAlgorithms {
    class OnePointBreeder<TGene> : ICrossoverInt<TGene>, ISteadyStateCrossoverInt<TGene> {
        private Generation<TGene> _generation;

        public OnePointBreeder(Generation<TGene> generation) => _generation = generation;

        public void MultipleCross((int, int)[] parents, IMutationInt<TGene> mutator) {
            IChromosomeInt<TGene> parent1,
                                  parent2,
                                  offspring;

            for (int i = 0; i < _generation.OffspringLength; i++) {
                parent1 = _generation.GetParent(parents[i].Item1);
                parent2 = _generation.GetParent(parents[i].Item2);
                offspring = _generation.GetOffspring(i);

                int crossPoint = Randomizer.Next(offspring.Length - 1);

                for (int j = 0; j <= crossPoint; j++) {
                    offspring[j] = parent1[j];
                }

                for (int j = crossPoint; j < offspring.Length; j++) {
                    offspring[j] = parent2[j];
                }

                mutator.Mutate(offspring);
            }
        }

        public void SimpleCrossWithMultipleSolutions((int, int) parents, IMutationInt<TGene> mutator) {
            IChromosomeInt<TGene> parent1 = _generation.GetParent(parents.Item1);
            IChromosomeInt<TGene> parent2 = _generation.GetParent(parents.Item2);
            IChromosomeInt<TGene> offspring1 = _generation.GetOffspring(0);
            IChromosomeInt<TGene> offspring2 = _generation.GetOffspring(1);

            int crossPoint = Randomizer.Next(offspring1.Length - 1);

            for (int j = 0; j <= crossPoint; j++) {
                offspring1[j] = parent1[j];
                offspring2[j] = parent2[j];
            }

            for (int j = crossPoint; j < offspring1.Length; j++) {
                offspring1[j] = parent2[j];
                offspring2[j] = parent1[j];
            }

            mutator.Mutate(offspring1);
            mutator.Mutate(offspring2);
        }
    }
}

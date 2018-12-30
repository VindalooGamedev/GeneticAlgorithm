namespace GeneticAlgorithms {
    /// <summary>
    /// This Crossover Operator do the crossover of each locus 
    /// selecting one of the parents gene at 50% of chance each.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    class UniformBreeder<TGene> : ICrossoverInt, ISteadyStateCrossoverInt<TGene> {
        private Generation<TGene> _generation;

        public UniformBreeder(Generation<TGene> generation) => _generation = generation;

        public void MultipleCross((int, int)[] parents) {

            IChromosomeInt<TGene> parent1,
                                  parent2,
                                  offspring;

            for (int i = 0; i < _generation.OffspringLength; i++) {
                parent1 = _generation.GetParent(parents[i].Item1);
                parent2 = _generation.GetParent(parents[i].Item2);
                offspring = _generation.GetOffspring(i);

                for (int j = 0; j < offspring.Length; j++) {
                    offspring[j] = (Randomizer.Next(2) == 0) ? parent1[j] : parent2[j];
                }
            }
        }

        public void SimpleCrossWithMultipleSolutions((int, int) parents) {
            IChromosomeInt<TGene> parent1 = _generation.GetParent(parents.Item1);
            IChromosomeInt<TGene> parent2 = _generation.GetParent(parents.Item2);
            IChromosomeInt<TGene> offspring1 = _generation.GetOffspring(0);
            IChromosomeInt<TGene> offspring2 = _generation.GetOffspring(1);

            for (int j = 0; j < offspring1.Length; j++) {
                if (Randomizer.Next(2) == 0) {
                    offspring1[j] = parent1[j];
                    offspring2[j] = parent2[j];
                }
                else {
                    offspring1[j] = parent2[j];
                    offspring2[j] = parent1[j];
                }
            }
        }
    }
}

namespace GeneticAlgorithms {
    class UniformBreeder<TGene> : ICrossoverInt {
        private Generation<TGene> _generation;

        public UniformBreeder(Generation<TGene> generation) => _generation = generation;

        public void Cross((int, int)[] parents) {

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
    }
}

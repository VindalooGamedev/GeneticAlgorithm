namespace GeneticAlgorithms {
    /// <summary>
    /// This Mutation Operator mutate each Gene idependently with an immutable chance.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    class UniformMutator<TGene> : IMutationInt {
        private FitnessSortedGeneration<TGene> _generation;
        private bool _elitism;
        private int _chance, _of;

        public UniformMutator(FitnessSortedGeneration<TGene> generation, int chance, int of, bool elitism) {
            _generation = generation;
            _chance = chance;
            _of = of;
            _elitism = elitism;
        }

        public void Mutate() {
            for (int i = (_elitism) ? 1 : 0; i < _generation.ParentsLength; i++) {
                IChromosomeInt<TGene> chromosome = _generation.GetParent(i);
                for (int j = 0; j < chromosome.Length; j++) {
                    if (Randomizer.Next(_of) < _chance) {
                        chromosome.Mutate(j);
                    }
                }
            }
        }
    }
}

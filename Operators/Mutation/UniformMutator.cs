namespace GeneticAlgorithms {
    class UniformMutator<TGene> : IMutationInt {
        private Generation<TGene> _generation;
        private bool _elitism;
        private int _chance, _of;

        public UniformMutator(Generation<TGene> generation, int chance, int of, bool elitism) {
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

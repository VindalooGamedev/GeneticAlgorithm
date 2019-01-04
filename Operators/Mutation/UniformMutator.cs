namespace GeneticAlgorithms {
    /// <summary>
    /// This Mutation Operator mutate each Gene idependently with an immutable chance.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public class UniformMutator<TGene> : IMutationInt<TGene> {
        private int _chance, _of;

        public UniformMutator(int chance, int of) {
            _chance = chance;
            _of = of;
        }

        public void Mutate(IChromosomeInt<TGene> chromosome) {
            for (int j = 0; j < chromosome.Length; j++) {
                if (Randomizer.Next(_of) < _chance) {
                    chromosome.Mutate(j);
                }
            }
        }
    }
}

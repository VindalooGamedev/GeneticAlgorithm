namespace GeneticAlgorithms {
    /// <summary>
    /// This Mutation Operator mutate each Gene idependently with an immutable chance.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public class UniformMut<TGene> : IMutInt<TGene> {
        private int _chance, _of;

        public UniformMut(int chance, int of) {
            _chance = chance;
            _of = of;
        }

        public void Mutate(IChromoInt<TGene> chromo) {
            for (int j = 0; j < chromo.Length; j++) {
                if (Randomizer.Next(_of) < _chance) {
                    chromo.Mutate(j);
                }
            }
        }
    }
}

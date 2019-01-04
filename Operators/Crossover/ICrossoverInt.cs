namespace GeneticAlgorithms {
    public interface ICrossoverInt<TGene> {
        void MultipleCross((int, int)[] parents, IMutationInt<TGene> mutator);
    }

    public interface ISteadyStateCrossoverInt<TGene> {
        void SimpleCrossWithMultipleSolutions((int, int) parents, IMutationInt<TGene> mutator);
    }
}

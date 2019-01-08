namespace GeneticAlgorithms {
    public interface ICrossInt<TGene> {
        void MultipleCross((int, int)[] parents, IMutInt<TGene> mutator);
    }

    public interface ISteaStaCrossInt<TGene> {
        void SimpleCrossWithMultipleSolutions((int, int) parents, IMutInt<TGene> mutator);
    }
}

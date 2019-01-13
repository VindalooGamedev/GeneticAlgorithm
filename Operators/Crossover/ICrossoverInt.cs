namespace GeneticAlgorithms {
    public interface ICrossInt<TGene> {
        Gen<TGene> Gen { get; set; }
        void MultipleCross((int, int)[] parents, IMutInt<TGene> mutator);
    }

    public interface ISteaStaCrossInt<TGene> {
        Gen<TGene> Gen { get; set; }
        void SimpleCrossWithMultipleSolutions((int, int) parents, IMutInt<TGene> mutator);
    }
}

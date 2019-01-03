namespace GeneticAlgorithms {
    internal interface ICrossoverInt {
        void MultipleCross((int, int)[] parents);
    }

    internal interface ISteadyStateCrossoverInt<TGene> {
        void SimpleCrossWithMultipleSolutions((int, int) parents);
    }
}

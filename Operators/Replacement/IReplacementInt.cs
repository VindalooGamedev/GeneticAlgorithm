namespace GeneticAlgorithms {
    internal interface IReplacementInt {
        void MakeRoom();
    }
    internal interface ISteadyStateReplacementInt<TGene> {
        void ReplaceComparingWithOffsprings((int, int) parents);
    }
}

namespace GeneticAlgorithms {
    public interface IReplacementInt {
        void MakeRoom();
    }

    public interface ISteadyStateReplacementInt<TGene> {
        void ReplaceComparingWithOffsprings((int, int) parents);
    }
}

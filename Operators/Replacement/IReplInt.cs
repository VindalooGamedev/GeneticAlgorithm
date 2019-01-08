namespace GeneticAlgorithms {
    public interface IReplInt {
        void MakeRoom();
    }

    public interface ISteStaReplInt<TGene> {
        void ReplaceComparingWithOffs((int, int) pars);
    }
}

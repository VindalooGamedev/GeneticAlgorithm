namespace GeneticAlgorithms {
    public interface IReplInt<TGene> {
        void MakeRoom();
    }

    public interface ISteStaReplInt<TGene> {
        void ReplaceComparingWithOffs((int, int) pars);
    }
}

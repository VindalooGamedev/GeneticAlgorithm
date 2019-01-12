namespace GeneticAlgorithms {
    public interface IReplInt<TGene> {
        Gen<TGene> Gen { get; set; }
        void MakeRoom();
    }

    public interface ISteStaReplInt<TGene> {
        Gen<TGene> Gen { get; set; }
        void ReplaceComparingWithOffs((int, int) pars);
    }
}

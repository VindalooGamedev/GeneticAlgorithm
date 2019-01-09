namespace GeneticAlgorithms {
    public interface ITermCondInt<TGene> {
        bool IsMetIn(Gen<TGene> gen);
    }
}

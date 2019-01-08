namespace GeneticAlgorithms {
    public interface ITermCondInt<TGene> {
        bool IsMetIn(GenBase<TGene> gen);
    }
}

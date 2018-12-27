namespace GeneticAlgorithms {
    public interface ITerminationConditionInt<TGene> {
        bool IsMetIn(Generation<TGene> generation);
    }
}

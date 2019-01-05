namespace GeneticAlgorithms {
    public interface ITerminationConditionInt<TGene> {
        bool IsMetIn(GenerationBase<TGene> generation);
    }
}

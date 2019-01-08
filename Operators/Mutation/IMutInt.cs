namespace GeneticAlgorithms {
    public interface IMutInt<TGene> {
        void Mutate(IChromoInt<TGene> chromo);
    }
}

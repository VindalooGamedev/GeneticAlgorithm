namespace GeneticAlgorithms {
    public interface IMutationInt<TGene> {
        void Mutate(IChromosomeInt<TGene> chromosome);
    }
}

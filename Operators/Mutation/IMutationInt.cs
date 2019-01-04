namespace GeneticAlgorithms {
    public interface IMutationInt<TGene> {
        void Mutate();
        void Mutate(IChromosomeInt<TGene> chromosome);
    }
}

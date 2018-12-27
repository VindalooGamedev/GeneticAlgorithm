namespace GeneticAlgorithms {
    public interface IChromosomeInt<TGene> {
        TGene this[int index] { get; set; }
        int Length { get; }
        void Mutate(int geneIndex);
        int Fitness { get; }
    }
}

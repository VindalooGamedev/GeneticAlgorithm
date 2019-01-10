namespace GeneticAlgorithms {
    public interface IExecutor<TGene> {
        SolutionInt<TGene> Run();
        void SetGeneration(Gen<TGene> generation);
    }
}
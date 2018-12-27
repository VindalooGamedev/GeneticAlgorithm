namespace GeneticAlgorithms {
    public class SolutionInt<TGene> {
        private FitnessSortedGeneration<TGene> _generation;

        public SolutionInt(FitnessSortedGeneration<TGene> generation) => _generation = generation;
    }
}

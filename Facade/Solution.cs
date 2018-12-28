namespace GeneticAlgorithms {
    // This class must be used in the future to cover solutions of the Genetic Algorithm results.
    // That could involve performance study or at least important values like minimum and maximum.
    public class SolutionInt<TGene> {
        private FitnessSortedGeneration<TGene> _generation;

        public SolutionInt(FitnessSortedGeneration<TGene> generation) => _generation = generation;
    }
}

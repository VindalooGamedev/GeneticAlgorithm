namespace GeneticAlgorithms {
    // This class must be used in the future to cover solutions of the Genetic Algorithm results.
    // That could involve performance study or at least important values like minimum and maximum.
    public class SolutionInt<TGene> {
        private GenBase<TGene> _generation;

        public SolutionInt(GenBase<TGene> generation) => _generation = generation;
    }
}

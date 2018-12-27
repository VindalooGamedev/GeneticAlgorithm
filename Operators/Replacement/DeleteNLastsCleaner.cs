namespace GeneticAlgorithms {
    class DeleteNLastsCleaner<TGene> : IReplacementInt {
        private FitnessSortedGeneration<TGene> _generation;
        private int _n;

        public DeleteNLastsCleaner(FitnessSortedGeneration<TGene> generation, int n) {
            _generation = generation;
            _n = n;
        }

        public void MakeRoom() => _generation.RemoveLasts(_n);
    }
}

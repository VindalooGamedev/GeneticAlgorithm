using System;

namespace GeneticAlgorithms {
    internal class ChromosomeAdapter<TGene> : IChromosomeInt<TGene>, IComparable<IChromosomeInt<TGene>> {
        private IChromosomeInt<TGene> _chromosome;

        // Lazy Pattern and cached value for Fitness
        private int? _cachedFitness;
        public int Fitness => (_cachedFitness ?? (_cachedFitness = _chromosome.Fitness)).Value;

        public int Length => _chromosome.Length;
        public TGene this[int index] {
            get => _chromosome[index];
            set {
                _chromosome[index] = value;
                _cachedFitness = null;
            }
        }

        public ChromosomeAdapter(IChromosomeInt<TGene> chromosome) => _chromosome = chromosome;

        // ICromosomeInt implementation
        public void Mutate(int geneIndex) => _chromosome.Mutate(geneIndex);

        // IComparable Implementation
        public int CompareTo(IChromosomeInt<TGene> other) => Fitness.CompareTo(other.Fitness);
    }
}

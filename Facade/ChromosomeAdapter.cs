using System;
namespace GeneticAlgorithms {

    /// <summary>
    /// This class works as an adapter of the real chromosome to cover some features.
    ///  - It implement lazy pattern of the value of Fitness to avoid heavy calcs.
    ///  - It implements IComparable using Fitness as value to compare.
    /// </summary>
    internal class ChromosomeAdapter<TGene> : IChromosomeInt<TGene>, IComparable<IChromosomeInt<TGene>> {
        private IChromosomeInt<TGene> _chromosome;

        // Lazy Pattern and cached value for Fitness
        private int? _cachedFitness;
        public int Fitness => (_cachedFitness ?? (_cachedFitness = _chromosome.Fitness)).Value;

        // Array like interface to access genes by their locus.
        public int Length => _chromosome.Length;
        public TGene this[int index] {
            get => _chromosome[index];
            set {
                _chromosome[index] = value;
                _cachedFitness = null;
            }
        }

        // Constructor
        public ChromosomeAdapter(IChromosomeInt<TGene> chromosome) => _chromosome = chromosome;

        // ICromosomeInt implementation
        public void Mutate(int geneIndex) => _chromosome.Mutate(geneIndex);

        // IComparable Implementation
        public int CompareTo(IChromosomeInt<TGene> other) => Fitness.CompareTo(other.Fitness);
    }
}

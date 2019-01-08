using System;

namespace GeneticAlgorithms {
    /// <summary>
    /// This class works as an adapter of the real chromosome to cover some features.
    ///  - It implement lazy pattern of the value of Fitness to avoid heavy calcs.
    ///  - It implements IComparable using Fitness as value to compare.
    /// </summary>
    internal class ChromoAdapter<TGene> : IChromoInt<TGene>, IComparable<IChromoInt<TGene>> {
        private IChromoInt<TGene> _chromo;

        // Lazy Pattern and cached value for Fitness
        private int? _cachedFit;
        public int Fit => (_cachedFit ?? (_cachedFit = _chromo.Fit)).Value;

        // Array like interface to access genes by their locus.
        public int Length => _chromo.Length;
        public TGene this[int index] {
            get => _chromo[index];
            set {
                _chromo[index] = value;
                _cachedFit = null;
            }
        }

        // Constructor
        public ChromoAdapter(IChromoInt<TGene> chromosome) => _chromo = chromosome;

        // ICromosomeInt implementation
        public void Mutate(int geneIndex) => _chromo.Mutate(geneIndex);

        // IComparable Implementation
        public int CompareTo(IChromoInt<TGene> other) => Fit.CompareTo(other.Fit);
    }
}

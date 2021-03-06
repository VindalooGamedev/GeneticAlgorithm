﻿namespace GeneticAlgorithms {
    // Public interface that each chromosome that the user want to use must implement.
    public interface IChromoInt<TGene> {
        TGene this[int index] { get; set; }
        int Length { get; }
        void Mutate(int geneIndex);
        int Fit { get; }
    }
}

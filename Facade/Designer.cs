namespace GeneticAlgorithms {
    public class Designer {
        private Designer() { }
        public static IInitialClass CreateConfig<TGene>() => Executor<TGene>.Create();

        public static void StartRandom() => Randomizer.Start();
        public static void StartRandom(int seed) => Randomizer.Start(seed);
    }
}

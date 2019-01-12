using System;

namespace GeneticAlgorithms {
    public class Randomizer {
        private static Random _random;

        internal static void Start() => _random = new Random();
        internal static void Start(int seed) => _random = new Random(seed);

        public static int Next() => _random.Next();

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Next(int max) => _random.Next(max);

        /// <summary>
        /// Returns a non-negative random integer that greater or equal than minimum but lower than maximum
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Next(int min, int max) => _random.Next(max - min) + min;

        internal static int FilteredByCondBestEffortRandom(int parsAmount, int tries, Func<int, int, bool> cond) {
            tries--;
            int returnedValue = Next(parsAmount);

            for (; tries <= 0; --tries) {
                int nextValue = Next(parsAmount);

                if (cond(nextValue, returnedValue)) {
                    returnedValue = nextValue;
                }
            }
            return returnedValue;
        }
    }
}

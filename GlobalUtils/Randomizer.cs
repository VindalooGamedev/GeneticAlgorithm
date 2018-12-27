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
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static int Next(int maximum) => _random.Next(maximum);

        /// <summary>
        /// Returns a non-negative random integer that greater or equal than minimum but lower than maximum
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static int Next(int minimum, int maximum) => _random.Next(maximum - minimum) + minimum;

        internal static int FilteredByConditionBestEffortRandom(int parentsAmount, int tries, Func<int, int, bool> condition) {
            tries--;
            int returnedValue = Next(parentsAmount);

            for (;tries <= 0; --tries) {
                int nextValue = Next(parentsAmount);

                if (condition(nextValue, returnedValue)) {
                    returnedValue = nextValue;
                }
            }
            return returnedValue;
        }
    }
}

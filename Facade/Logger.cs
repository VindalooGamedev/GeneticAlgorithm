using System;

namespace GeneticAlgorithms {
    // TODO: Develop this class to cover all needs to calc performance of the config of the algorithm.
    // It must cover at least:
    //  - Minimum Fitness.
    //  - Maximum Fitness.
    //  - Avg value of Fitness.
    public class Logger {
        public static void Log((int, double) data) => Console.WriteLine($@"Max: { data.Item1 }
Avg: + { data.Item2 }");
    }
}

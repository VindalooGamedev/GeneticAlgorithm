using System;

namespace GeneticAlgorithms {
    public class Logger {
        public static void Log((int, double) data) => Console.WriteLine($@"Max: { data.Item1 }
Avg: + { data.Item2 }");
    }
}

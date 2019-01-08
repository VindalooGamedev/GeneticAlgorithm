namespace GeneticAlgorithms {
    public interface ISelInt {
        (int, int)[] GetPairedParsForEveryOff();
    }

    public interface ISteStaSelInt {
        (int, int) GetPairedParsOnce();
    }
}

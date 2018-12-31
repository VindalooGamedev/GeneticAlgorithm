namespace GeneticAlgorithms {
    public interface ISelectionInt {
        (int, int)[] GetPairedParentsForEveryOffspring();
    }

    public interface ISteadyStateSelectionInt {
        (int, int) GetPairedParentsOnce();
    }
}

namespace GeneticAlgorithms {
    internal interface ISelectionInt {
        (int, int)[] GetPairedParentsForEveryOffspring();
    }

    internal interface ISteadyStateSelectionInt {
        (int, int) GetPairedParentsOnce();
    }
}

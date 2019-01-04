using System;

namespace GeneticAlgorithms {
    // This interface is used to group all states in one whole.
    // If some types in the future can have subsets of this group 
    internal interface IGrouped<TGene> :
        IInitialClass, IGenerationSetted, IReplacementSetted,
        ISelectionSetted, ICrossoverSetted, IMutationSetted,
        ITerminationConditionSetted, IFinalClass<TGene> { }

    // Viable states that are covered by Facade
    public interface IInitialClass { }
    public interface IGenerationSetted { }
    public interface IReplacementSetted { }
    public interface ISelectionSetted { }
    public interface ICrossoverSetted { }
    public interface IMutationSetted { }
    public interface ITerminationConditionSetted { }
    public interface IFinalClass<TGene> { SolutionInt<TGene> Run(); }

    // All actions viable by the interface sorted by interface used as "this parameter"
    public static class SomeFluentExtensions {
        public static IGenerationSetted FitnessSortedGeneration<TGene>(this IInitialClass item, IChromosomeInt<TGene>[] chromosomes) {
            ((Executor<TGene>)item).DoSetGeneration(chromosomes);
            return (IGenerationSetted)item;
        }

        public static IReplacementSetted DeleteNLastsCleaner<TGene>(this IGenerationSetted item, int n) {
            ((Executor<TGene>)item).DoSetDeleteNLastsCleaner(n);
            return (IReplacementSetted)item;
        }

        public static ISelectionSetted TournamentSelector<TGene>(this IReplacementSetted item, int k) {
            ((Executor<TGene>)item).DoSetTournamentSelector(k);
            return (ISelectionSetted)item;
        }

        public static ISelectionSetted RankSelector<TGene>(this IReplacementSetted item) {
            ((Executor<TGene>)item).DoSetRankSelector();
            return (ISelectionSetted)item;
        }

        public static ISelectionSetted RouletteWheelSelector<TGene>(this IReplacementSetted item) {
            ((Executor<TGene>)item).DoSetRouletteWheelSelector();
            return (ISelectionSetted)item;
        }

        public static ISelectionSetted RouletteWheelLFSSelector<TGene>(this IReplacementSetted item) {
            ((Executor<TGene>)item).DoSetRouletteWheelLFSSelector();
            return (ISelectionSetted)item;
        }

        /*
        public static ICrossoverSetted UniformBreeder<TGene>(this ISelectionSetted item) {
            ((Executor<TGene>)item).DoSetCrossover();
            return (ICrossoverSetted)item;
        }*/

        public static IMutationSetted UniformMutator<TGene>(this ICrossoverSetted item, int chance, int of, bool elitism) {
            ((Executor<TGene>)item).DoSetMutation(chance, of, elitism);
            return (IMutationSetted)item;
        }

        public static ITerminationConditionSetted SetTerminationCondition<TGene>(this IMutationSetted item, ITerminationConditionInt<TGene> terminationCondition) {
            ((Executor<TGene>)item).DoSetTerminationCondition(terminationCondition);
            return (ITerminationConditionSetted)item;
        }

        public static IFinalClass<TGene> Done<TGene>(this ITerminationConditionSetted item) => ((Executor<TGene>)item).DoDone();
    }

    // Partial class that implements the facade part of the class, all DoActions are sorted by operator type.
    public partial class Executor<TGene> : IGrouped<TGene> {
        // Limitation needed at the construction phase.
        private Executor() { }
        public static IInitialClass Create() => new Executor<TGene>();

        // Generation Type.
        protected internal void DoSetGeneration(IChromosomeInt<TGene>[] chromosomes) 
            => _generation = new FitnessSortedGeneration<TGene>(chromosomes);

        // Replacement Strategy.
        protected internal void DoSetDeleteNLastsCleaner(int n) 
            => _cleaner = new DeleteNLastsCleaner<TGene>((FitnessSortedGeneration<TGene>)_generation, n);

        // Selection Strategy.
        protected internal void DoSetTournamentSelector(int k) 
            => _parentSelector = new TournamentSelector<TGene>((FitnessSortedGeneration<TGene>)_generation, k);

        protected internal void DoSetRankSelector() 
            => _parentSelector = new RankSelector<TGene>((FitnessSortedGeneration<TGene>)_generation);

        internal void DoSetRouletteWheelSelector()
            => _parentSelector = new RouletteWheelSelectorInt<TGene>(_generation);

        internal void DoSetRouletteWheelLFSSelector()
            => _parentSelector = new RouletteWheelLFSSelectorInt<TGene>(_generation);

        // Crossover Strategy.
        //protected internal void DoSetCrossover()  => _breeder = new UniformBreeder<TGene>(_generation);

        // Mutation Strategy.
        protected internal void DoSetMutation(int chance, int of, bool elitism) 
            => _mutator = new UniformMutator<TGene>((FitnessSortedGeneration<TGene>)_generation, chance, of, elitism);

        // Termination Condition.
        protected internal void DoSetTerminationCondition(ITerminationConditionInt<TGene> terminationCondition) 
            => _terminationCondition = terminationCondition;

        // Last step that reveals the interface to be used.
        internal virtual IFinalClass<TGene> DoDone() => this;

    }
}

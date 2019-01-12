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
    public interface IFinalClass<TGene> { void Run(); }

    // All actions viable by the interface sorted by interface used as "this parameter"
    public static class SomeFluentExtensions {
        public static IGenerationSetted FitnessSortedGeneration<TGene>(this IInitialClass item, IChromoInt<TGene>[] chromosomes) {
            ((Executor<TGene>)item).DoSetGeneration(chromosomes);
            return (IGenerationSetted)item;
        }

        public static IReplacementSetted DeleteNLastsCleaner<TGene>(this IGenerationSetted item, Gen<TGene> gen, int n) {
            ((Executor<TGene>)item).DoSetDeleteNLastsCleaner(gen, n);
            return (IReplacementSetted)item;
        }

        public static ISelectionSetted TournamentSelector<TGene>(this IReplacementSetted item, Gen<TGene> gen, int k) {
            ((Executor<TGene>)item).DoSetTournamentSelector(gen, k);
            return (ISelectionSetted)item;
        }

        public static ISelectionSetted RankSelector<TGene>(this IReplacementSetted item, Gen<TGene> gen) {
            ((Executor<TGene>)item).DoSetRankSelector(gen);
            return (ISelectionSetted)item;
        }

        public static ISelectionSetted RouletteWheelSelector<TGene>(this IReplacementSetted item, Gen<TGene> gen) {
            ((Executor<TGene>)item).DoSetRouletteWheelSelector(gen);
            return (ISelectionSetted)item;
        }

        public static ISelectionSetted RouletteWheelLFSSelector<TGene>(this IReplacementSetted item, Gen<TGene> gen) {
            ((Executor<TGene>)item).DoSetRouletteWheelLFSSelector(gen);
            return (ISelectionSetted)item;
        }

        /*
        public static ICrossoverSetted UniformBreeder<TGene>(this ISelectionSetted item) {
            ((Executor<TGene>)item).DoSetCrossover();
            return (ICrossoverSetted)item;
        }

        public static IMutationSetted UniformMutator<TGene>(this ICrossoverSetted item, int chance, int of, bool elitism) {
            ((Executor<TGene>)item).DoSetMutation(chance, of, elitism);
            return (IMutationSetted)item;
        }
        */
        public static ITerminationConditionSetted SetTerminationCondition<TGene>(this IMutationSetted item, ITermCondInt<TGene> terminationCondition) {
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
        protected internal void DoSetGeneration(IChromoInt<TGene>[] chromosomes)
            => _gen = new Gen<TGene>(chromosomes);

        // Replacement Strategy.
        protected internal void DoSetDeleteNLastsCleaner(Gen<TGene> gen, int n)
            => _cleaner = new DeleteNLastsRepl<TGene>(gen, n);

        // Selection Strategy.
        protected internal void DoSetTournamentSelector(Gen<TGene> gen, int k)
            => _parentSelector = new TournamentSel<TGene>(gen, k);

        protected internal void DoSetRankSelector(Gen<TGene> gen)
            => _parentSelector = new RankSel<TGene>(gen);

        internal void DoSetRouletteWheelSelector(Gen<TGene> gen)
            => _parentSelector = new RouletteWheelSelInt<TGene>(gen);

        internal void DoSetRouletteWheelLFSSelector(Gen<TGene> gen)
            => _parentSelector = new RouletteWheelLFSSelInt<TGene>(gen);

        // Crossover Strategy.
        //protected internal void DoSetCrossover()  => _breeder = new UniformBreeder<TGene>(_generation);

        // Mutation Strategy.
        //protected internal void DoSetMutation(int chance, int of, bool elitism) => _mutator = new UniformMutator<TGene>((FitnessSortedGeneration<TGene>)_generation, chance, of, elitism);

        // Termination Condition.
        protected internal void DoSetTerminationCondition(ITermCondInt<TGene> terminationCondition)
            => _termCond = terminationCondition;

        // Last step that reveals the interface to be used.
        internal virtual IFinalClass<TGene> DoDone() => this;

    }
}

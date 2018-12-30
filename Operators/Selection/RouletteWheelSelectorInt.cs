namespace GeneticAlgorithms {
    // TODO: It needs to be tested.
    /// <summary>
    /// This Selection Operator weights chance to be selected for each chromosome fitness,
    /// the higher the fitness the higher the chance to be selected to be a parent.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public partial class RouletteWheelSelectorInt<TGene> : ISelectionInt, ISteadyStateSelectionInt {
        private Generation<TGene> _generation;
        private int _fitnessSum;

        public RouletteWheelSelectorInt(Generation<TGene> generation) => _generation = generation;

        public (int, int)[] GetPairedParentsForEveryOffspring() {
            // Preparing the scope.
            (int, int)[] pairedParents = new(int, int)[_generation.OffspringLength];
            PrepareData();

            // Choose all pairs.
            for (var i = 0; i < pairedParents.Length; i++) {
                pairedParents[i].Item1 = GetFirstParent();
                pairedParents[i].Item2 = GetSecondParent(pairedParents[i].Item1);
            }
            return pairedParents;
        }

        private void PrepareData() {
            _fitnessSum = 0;
            for (int i = 0; i < _generation.ParentsLength; i++) {
                _fitnessSum += _generation.GetParent(i).Fitness;
            }
        }

        public (int, int) GetPairedParentsOnce() {
            PrepareData();
            int firstParent = GetFirstParent();
            return (firstParent, GetSecondParent(firstParent));
        }

        private int GetFirstParent() {
            int position = Randomizer.Next(0, _fitnessSum);
            int chromosome = -1;
            do {
                chromosome++;
                position -= _generation.GetParent(chromosome).Fitness;
            } while (position > 0);
            return chromosome;
        }

        private int GetSecondParent(int otherParent) {
            int position = Randomizer.Next(0, _fitnessSum - (_generation.GetParent(otherParent).Fitness));
            int chromosome = -1;
            do {
                chromosome++;
                if (chromosome == otherParent) {
                    chromosome++;
                }
                position -= _generation.GetParent(chromosome).Fitness;
            } while (position > 0);
            return chromosome;
        }
    }
}

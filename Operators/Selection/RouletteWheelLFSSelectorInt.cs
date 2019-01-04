namespace GeneticAlgorithms {
    // TODO: It needs to be tested.
    /// <summary>
    /// This Selection Operator weights chance to be selected for each chromosome fitness,
    /// the higher the fitness the higher the chance to be selected to be a parent.
    /// This version gets the statistics to center the focus on higher values, it reduces the problem
    /// where all values are high and there is almost no weight on being higher.
    /// </summary>
    /// <typeparam name="TGene">Type of the genes uses in the chromosome definition.</typeparam>
    public partial class RouletteWheelLFSSelectorInt<TGene> : SelectorBase<Generation<TGene>, TGene> {
        private int[] _fitnesses;
        private int _fitnessSum;

        public RouletteWheelLFSSelectorInt(Generation<TGene> generation) => _generation = generation;

        protected override void PrepareData() {
            int initialSum = 0;
            for (int i = 0; i < _generation.ParentsLength; i++) {
                initialSum += _generation.GetParent(i).Fitness;
            }

            int mean = initialSum / _generation.ParentsLength;
            int min = mean - (_generation.MaximumFitness - mean);


            _fitnesses = new int[_generation.ParentsLength];
            for (int i = 0; i < _generation.ParentsLength; i++) {
                _fitnesses[i] = _generation.GetParent(i).Fitness - min;
                if (_fitnesses[i] < 0) {
                    _fitnesses[i] = 0;
                }
            }

            _fitnessSum = 0;
            for (int i = 0; i < _fitnesses.Length; i++) {
                _fitnessSum += _fitnesses[i];
            }
        }

        protected override int GetFirstParent() {
            int position = Randomizer.Next(0, _fitnessSum);
            int chromosome = -1;
            do {
                chromosome++;
                position -= _fitnesses[chromosome];
            } while (position > 0);
            return chromosome;
        }

        protected override int GetSecondParent(int otherParent) {
            int position = Randomizer.Next(0, _fitnessSum - (_fitnesses[otherParent]));
            int chromosome = -1;
            do {
                chromosome++;
                if (chromosome == otherParent) {
                    chromosome++;
                }
                position -= _fitnesses[chromosome];
            } while (position > 0);
            return chromosome;
        }
    }
}

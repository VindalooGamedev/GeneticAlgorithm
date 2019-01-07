using System;

namespace GeneticAlgorithms {
    public class Generation<TGene> {
        private IChromosomeInt<TGene>[] _chromosomes;

        private bool IsUnsorted { get; set; } = true;
        public bool FitSorted { get; set; }
        public int OffspringLength { get; private set; }
        public int ParentsLength { get; private set; }
        public int MinFit { get; private set; }
        public int MaxFit { get; private set; }
        public int GenCount { get; private set; } = 0;

        public IChromosomeInt<TGene> GetParent(int index) 
            => _chromosomes[index];

        public IChromosomeInt<TGene> GetOffspring(int index)
            => _chromosomes[OffspringAdress(index)];

        private int OffspringAdress(int index)
            => _chromosomes.Length - OffspringLength + index;

        public Generation(IChromosomeInt<TGene>[] chromosomes)
            => _chromosomes = chromosomes;

        public void UpdateGenerationData() {
            GenCount++;
            if (FitSorted) {
                SortByFitness();
            }
        }

        public void Switch(int parentId, int offspringId) {
            IChromosomeInt<TGene> auxParent = GetParent(parentId);
            _chromosomes[parentId] = GetOffspring(offspringId);
            _chromosomes[OffspringAdress(offspringId)] = auxParent;
        }

        public void FullSwitch() 
            => SwitchChunk((ParentsLength <= OffspringLength) ? ParentsLength : OffspringLength);

        public void SwitchChunk(int length) {
            IChromosomeInt<TGene>[] auxArray = new IChromosomeInt<TGene>[length];
            int chunkOffset = ParentsLength - length;

            Array.Copy(_chromosomes, chunkOffset, auxArray, 0, length);
            Array.Copy(_chromosomes, OffspringAdress(0), _chromosomes, chunkOffset, length);
            Array.Copy(auxArray, 0, _chromosomes, OffspringAdress(0), length);
        }

        public void SortByFitness() 
            => SortByFitness(_chromosomes);

        protected void SortByFitness(IChromosomeInt<TGene>[] chromosomeArray)
            => Array.Sort(chromosomeArray, (a, b) => b.Fitness - a.Fitness);

        public void SortParentByFitness() 
            => SortByFitness(0, ParentsLength);

        public void SortOffspringsByFitness()
            => SortByFitness(OffspringAdress(0), OffspringLength);

        public void SortByFitness(int origin, int length) {
            IChromosomeInt<TGene>[] auxArray = new IChromosomeInt<TGene>[ParentsLength];

            Array.Copy(_chromosomes, origin, auxArray, 0, length);
            SortByFitness(auxArray);
            Array.Copy(auxArray, 0, _chromosomes, origin, length);
        }
    }
}

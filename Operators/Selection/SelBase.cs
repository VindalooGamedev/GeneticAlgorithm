namespace GeneticAlgorithms {
    public abstract class SelBase<TGene> {
        protected Gen<TGene> _gen;

        public SelBase(Gen<TGene> gen) => _gen = gen;

        public (int, int)[] GetPairedParsForEveryOff() {
            (int, int)[] pairedPars = new(int, int)[_gen.OffsLength];
            PrepareData();

            // Choose all pairs.
            for (var i = 0; i < pairedPars.Length; i++) {
                pairedPars[i].Item1 = GetFirstPar();
                pairedPars[i].Item2 = GetSecondPar(pairedPars[i].Item1);
            }
            return pairedPars;
        }

        protected abstract void PrepareData();

        protected abstract int GetFirstPar();
        protected abstract int GetSecondPar(int item1);

        public (int, int) GetPairedParsOnce() {
            PrepareData();
            int firstPar = GetFirstPar();
            return (firstPar, GetSecondPar(firstPar));
        }
    }
}

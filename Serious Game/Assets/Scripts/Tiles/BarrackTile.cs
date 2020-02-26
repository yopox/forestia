namespace Tiles {
    public abstract class BarrackAbstractTile : BuildingAbstractTile {
        private const string BarrackTileName = "Barrack";

        protected BarrackAbstractTile(int positionX, int positionY) : base(positionX, positionY, BarrackTileName) {
            AddAction(new Action("new unit", NewUnit));
        }

        public void NewUnit() {
            // TODO
        }
    }
}
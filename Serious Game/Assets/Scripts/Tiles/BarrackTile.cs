namespace Tiles {
    public abstract class BarrackTile : BuildingTile {
        private const string BarrackTileName = "Barrack";

        protected BarrackTile(int positionX, int positionY) : base(positionX, positionY, BarrackTileName) {
            AddAction(new Action("new unit", NewUnit));
        }

        public void NewUnit() {
            // TODO
        }
    }
}
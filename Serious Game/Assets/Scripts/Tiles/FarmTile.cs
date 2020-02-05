namespace Tiles {
    public abstract class FarmTile : BuildingTile {
        private const string FarmTileName = "Barrack";

        protected FarmTile(int positionX, int positionY) : base(positionX, positionY, FarmTileName) {
        }
    }
}
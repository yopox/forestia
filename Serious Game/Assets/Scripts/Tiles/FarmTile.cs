namespace Tiles {
    public abstract class FarmAbstractTile : BuildingAbstractTile {
        private const string FarmTileName = "Barrack";

        protected FarmAbstractTile(int positionX, int positionY) : base(positionX, positionY, FarmTileName) {
        }
    }
}
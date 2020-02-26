namespace Tiles {
    public class FarmFieldAbstractTile : BuildingAbstractTile {
        private const string FarmTileName = "Field";

        public FarmFieldAbstractTile(int positionX, int positionY) : base(positionX, positionY, FarmTileName) {
        }
    }
}
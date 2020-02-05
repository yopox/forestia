namespace Tiles {
    public class FarmFieldTile : BuildingTile {
        private const string FarmTileName = "Field";

        public FarmFieldTile(int positionX, int positionY) : base(positionX, positionY, FarmTileName) {
        }
    }
}
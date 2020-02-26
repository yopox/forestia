namespace Tiles {
    public abstract class BiodiversityAbstractTile : AbstractTile {
        // TODO bonus species

        protected BiodiversityAbstractTile(int positionX, int positionY, string name) : base(positionX, positionY, name) {
        }

        public int GetBiodiversityScore() {
            return Level * 10;
        }
    }
}
namespace Tiles {
    public class ForestTile : BiodiversityTile {
        private const string ForestTileName = "Forest";
        private bool _inFire;

        public ForestTile(int positionX, int positionY) : base(positionX, positionY, ForestTileName) {
            _inFire = false;
        }

        public void SetFire() {
            _inFire = true;
        }

        public new int GetBiodiversityScore() {
            if (_inFire) {
                return 0; // score of 0 if forest tile in fire
            }

            return base.GetBiodiversityScore();
        }
    }
}
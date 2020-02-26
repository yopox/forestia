using UnityEngine;

namespace Tiles {
    public class ForestTile : BiodiversityTile {
        private const string ForestTileName = "Forest";
        private bool _inFire;

        public bool InFire => _inFire;

        public ForestTile(Vector2Int position) : base(position, ForestTileName) {
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
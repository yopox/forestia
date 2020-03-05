using UnityEngine;

namespace Tiles {
    public class ForestTile : BiodiversityTile {
        private const string ForestTileName = "Forest";
        private bool _onFire;

        public bool OnFire => _onFire;

        public ForestTile(Vector2Int position) : base(position, ForestTileName) {
            _onFire = false;
        }

        public void SetFire() {
            _onFire = true;
        }
        
        public void SetNoFire() {
            _onFire = false;
        }

        public new int GetBiodiversityScore() {
            if (_onFire) {
                return 0; // score of 0 if forest tile in fire
            }

            return base.GetBiodiversityScore();
        }

        public override string GetDescription() {
            return _onFire ? "Forest on fire" : "Forest";
        }
    }
}
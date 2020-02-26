using UnityEngine;

namespace Tiles {
    public abstract class BiodiversityTile : Tile {
        // TODO bonus species

        protected BiodiversityTile(Vector2Int position, string name) : base(position, name) {
        }

        public int GetBiodiversityScore() {
            return Level * 10;
        }
    }
}
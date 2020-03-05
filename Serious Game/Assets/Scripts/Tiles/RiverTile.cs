using UnityEngine;

namespace Tiles {
    public class RiverTile : BiodiversityTile {
        private const string RiverTileName = "River";

        public RiverTile(Vector2Int position) : base(position, RiverTileName) {
        }

        public override string GetDescription() {
            return "River";
        }
    }
}
using UnityEngine;

namespace Tiles {
    public class FarmFieldTile : BuildingTile {
        private const string FarmTileName = "Field";

        public FarmFieldTile(Vector2Int position) : base(position, FarmTileName) {
        }
    }
}
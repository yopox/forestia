using UnityEngine;

namespace Tiles {
    public class FarmTile : BuildingTile {
        private const string FarmTileName = "Farm";

        protected FarmTile(Vector2Int position) : base(position, FarmTileName) {
        }
    }
}
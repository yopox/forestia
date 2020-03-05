using UnityEngine;

namespace Tiles {
    public class FarmTile : BuildingTile {
        private const string FarmTileName = "Farm";

        public FarmTile(Vector2Int position) : base(position, FarmTileName) {
        }

        public override string GetDescription() {
            return "A farm.";
        }
    }
}
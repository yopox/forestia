using UnityEngine;

namespace Tiles {
    public abstract class FarmTile : BuildingTile {
        private const string FarmTileName = "Barrack";

        protected FarmTile(Vector2Int position) : base(position, FarmTileName) {
        }
    }
}
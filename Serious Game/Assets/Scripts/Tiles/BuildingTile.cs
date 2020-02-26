using UnityEngine;

namespace Tiles {
    public abstract class BuildingTile : AbstractTile {
        protected BuildingTile(Vector2Int position, string name) : base(position, name) {
        }
    }
}
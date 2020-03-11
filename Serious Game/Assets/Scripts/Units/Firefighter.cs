using Actions;
using Tiles;
using UnityEngine;

namespace Units {
    public class Firefighter : Unit {
        public Firefighter(Vector2Int position) : base(position, "Firefighter", "Can extinguish fires.", 3, true, false) {
            AddAction(new PricedAction("Extinguish fire", ExtinguishFire, IsExtinguishActive,0));
        }

        public override GameObject Prefab => UnitManager.Instance.firefighter;
        
        public void ExtinguishFire() {
            var tile = ForestManager.Instance.GetTile(Position);
            ((ForestTile) tile).SetNoFire();
            ((ForestTile) tile).Level = 1;
            CurrentActionPoints = 0;
            ForestManager.Instance.UpdateTileMap();
        }

        public bool IsExtinguishActive() {
            if (!(CurrentActionPoints > 0)) {
                return false;
            }
            var tile = ForestManager.Instance.GetTile(Position);
            if (tile is ForestTile) {
                return ((ForestTile) tile).OnFire;
            }
            return false;
        }
    }
}
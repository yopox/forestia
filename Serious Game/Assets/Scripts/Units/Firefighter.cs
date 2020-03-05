using Actions;
using Tiles;
using UnityEngine;

namespace Units {
    public class Firefighter : Unit {
        public Firefighter(Vector2Int position) : base(position, "Firefighter", "Can extinguish fires.", 1, true, false) {
            AddAction(new PricedAction("estinguish fire", EstinguishFire, IsEstinguishActive,0));
        }

        public override GameObject Prefab => UnitManager.Instance.firefighter;
        
        public void EstinguishFire() {
            // TODO
        }

        public bool IsEstinguishActive() {
            var tile = ForestManager.Instance.GetTile(Position);
            if (tile is ForestTile) {
                return ((ForestTile) tile).InFire;
            }
            return false;
        }
    }
}
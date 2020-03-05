using Actions;
using Tiles;
using UnityEngine;

namespace Units {
    public class Firefighter : Unit {
        public Firefighter(Vector2Int position) : base(position) {
            AddAction(new PricedAction("estinguish fire", EstinguishFire, IsEstinguishActive,0));
        }

        public override string Name => "Firefighter";
        public override string Description => "Can extinguish fires.";
        public override int Speed => 1;
        public override bool Friendly => true;
        public override bool CPU => false;
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
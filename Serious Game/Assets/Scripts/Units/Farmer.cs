using UnityEngine;

namespace Units {
    public class Farmer : Unit {
        public Farmer(Vector2Int position) : base(position) {
        }

        public override string Name => "Farmer";
        public override string Description => "Need space.";
        public override int Speed => 1;
        public override bool Friendly => false;
        public override bool CPU => true;
        public override GameObject Prefab => UnitManager.Instance.farmer;
    }
}
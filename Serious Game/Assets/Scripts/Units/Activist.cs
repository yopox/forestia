using UnityEngine;

namespace Units {
    public class Activist : Unit {
        public Activist(Vector2Int position) : base(position) {
        }

        public override string Name => "Activist";
        public override string Description => "todo";
        public override int Speed => 1;
        public override bool Friendly => true;
        public override bool CPU => true;
        public override GameObject Prefab => UnitManager.Instance.activist;
    }
}
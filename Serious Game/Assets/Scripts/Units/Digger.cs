using UnityEngine;

namespace Units {
    public class Digger : Unit {
        public Digger(Vector2Int position) : base(position) {
        }

        public override string Name => "Digger";
        public override string Description => "Looks for gold.";
        public override int Speed => 1;
    }
}
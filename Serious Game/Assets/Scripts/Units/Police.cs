using UnityEngine;

namespace Units {
    public class Police : Unit {
        public Police(Vector2Int position) : base(position) {
        }

        public override string Name => "Police";
        public override string Description => "Helps protecting the forest.";
        public override int Speed => 2;
        public override bool Friendly => true;
        public override bool CPU => false;
    }
}
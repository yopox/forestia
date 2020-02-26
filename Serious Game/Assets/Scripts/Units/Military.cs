using UnityEngine;

namespace Units {
    public class Military : Unit {
        public Military(Vector2Int position) : base(position) {
        }

        public override string Name => "Military";
        public override string Description => "Helps protecting the forest.";
        public override int Speed => 2;
        public override bool Friendly => true;
        public override bool CPU => false;
    }
}
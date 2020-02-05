using UnityEngine;

namespace Units {
    public class Fireman : Unit {
        public Fireman(Vector2Int position) : base(position) {
        }

        public override string Name => "Fireman";
        public override string Description => "Can extinguish fires.";
        public override int Speed => 1;
        public override bool Friendly => true;
        public override bool CPU => false;
    }
}
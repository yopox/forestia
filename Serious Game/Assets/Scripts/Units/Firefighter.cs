using UnityEngine;

namespace Units {
    public class Firefighter : Unit {
        public Firefighter(Vector2Int position) : base(position) {
        }

        public override string Name => "Firefighter";
        public override string Description => "Can extinguish fires.";
        public override int Speed => 1;
        public override bool Friendly => true;
        public override bool CPU => false;
    }
}
using UnityEngine;

namespace Units {
    public class Researcher : Unit {
        public Researcher(Vector2Int position) : base(position) {
            AddAction(new UnitAction("search", Search, IsSearchActive));
        }

        public override string Name => "Researcher";
        public override string Description => "Can discover new species.";
        public override int Speed => 3;
        public override bool Friendly => true;
        public override bool CPU => false;

        public void Search() {
            // TODO
        }

        public bool IsSearchActive() {
            // TODO
            return true;
        }
    }
}
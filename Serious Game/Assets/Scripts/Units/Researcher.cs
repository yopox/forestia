using Tiles;
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
        public override GameObject Prefab => UnitManager.Instance.researcher;

        public void Search() {
            // TODO
        }

        public bool IsSearchActive() {
            var tile = ForestManager.Instance.GetTile(Position);
            return tile is ForestTile;
        }
    }
}
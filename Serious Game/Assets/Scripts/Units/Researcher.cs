using Actions;
using Tiles;
using UnityEngine;

namespace Units {
    public class Researcher : Unit {
        public Researcher(Vector2Int position) : base(position, "Researcher", "Can discover new species.", 3, true, false) {
            AddAction(new PricedAction("search", Search, IsSearchActive, 0));
        }

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
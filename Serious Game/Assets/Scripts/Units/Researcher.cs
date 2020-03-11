using Actions;
using Tiles;
using UnityEngine;

namespace Units {
    public class Researcher : Unit {
        public Researcher(Vector2Int position) : base(position, "Researcher", "Can discover new species.", 3, true,
            false) {
            AddAction(new DefaultUnitAction("Search", Search, IsSearchActive));
        }

        public override GameObject Prefab => UnitManager.Instance.researcher;

        public void Search() {
            var tile = ForestManager.Instance.GetTile(Position);
            if (!(tile is ForestTile)) {
                return;
            }
            GameState.Instance.biodiversity.Value += ((ForestTile) tile).GetBiodiversityScore();
            GameState.Instance.science.Value += ((ForestTile) tile).GetBiodiversityScore();
            GameState.Instance.UpdateTexts();
            InteractorManager.Instance.UpdateInteractorWithUnit(this);
            CurrentActionPoints = 0;
        }

        public bool IsSearchActive() {
            if (!(CurrentActionPoints > 0)) {
                return false;
            }

            var tile = ForestManager.Instance.GetTile(Position);
            return tile is ForestTile;
        }
    }
}
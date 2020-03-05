using Actions;
using Units;
using UnityEngine;

namespace Tiles {
    public class LaboratoryTile : BuildingTile {
        private const string LaboratoryTileName = "Laboratory";
        private const int ResearcherCost = 20;

        public LaboratoryTile(Vector2Int position) : base(position, LaboratoryTileName) {
            AddAction(new PricedAction("Hire", NewResearcher, IsNewResearcherActive,ResearcherCost));
        }

        public void NewResearcher() {
            GameState.Instance.money.Value -= ResearcherCost;
            GameState.Instance.UpdateTexts();
            UnitManager.Instance.SpawnUnit(new Researcher(Position));
        }

        public bool IsNewResearcherActive() {
            var unitOrNull = UnitManager.Instance.GetUnit(Position);
            return unitOrNull == null;
        }

        public override string GetDescription() {
            return "Researchers can be hired here.";
        }
    }
}
using Units;
using UnityEngine;

namespace Tiles {
    public class LaboratoryTile : BuildingTile {
        private const string LaboratoryTileName = "Laboratory";

        public LaboratoryTile(Vector2Int position) : base(position, LaboratoryTileName) {
            AddAction(new TileAction("new scientist", NewResearcher, IsNewResearcherActive,20));
        }

        public void NewResearcher() {
            UnitManager.Instance.SpawnUnit(new Researcher(Position));
        }

        public bool IsNewResearcherActive() {
            var unitOrNull = UnitManager.Instance.GetUnit(Position);
            return unitOrNull == null;
        }

        public override string GetDescription() {
            return "Laboratory building";
        }
    }
}
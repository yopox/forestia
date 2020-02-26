using Units;
using UnityEngine;

namespace Tiles {
    public class LaboratoryTile : BuildingTile {
        private const string LaboratoryTileName = "Laboratory";

        protected LaboratoryTile(Vector2Int position) : base(position, LaboratoryTileName) {
            AddAction(new TileAction("new researcher", NewResearcher, IsNewResearcherActive));
        }

        public void NewResearcher() {
            UnitManager.Instance.SpawnUnit(new Researcher(Position));
        }

        public bool IsNewResearcherActive() {
            // TODO
            return true;
        }
    }
}
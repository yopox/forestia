using Units;
using UnityEngine;

namespace Tiles {
    public abstract class LaboratoryTile : BuildingTile {
        private const string LaboratoryTileName = "Laboratory";

        protected LaboratoryTile(Vector2Int position) : base(position, LaboratoryTileName) {
            AddAction(new Action("new researcher", NewResearcher));
        }

        public void NewResearcher() {
            UnitManager.Instance.SpawnUnit(new Researcher(Position));
        }
    }
}
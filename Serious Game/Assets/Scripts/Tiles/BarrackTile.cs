using Units;
using UnityEngine;

namespace Tiles {
    public abstract class BarrackTile : BuildingTile {
        private const string BarrackTileName = "Barrack";

        protected BarrackTile(Vector2Int position) : base(position, BarrackTileName) {
            AddAction(new TileAction("new military", NewMilitary, IsNewMilitaryActive));
        }

        public void NewMilitary() {
            UnitManager.Instance.SpawnUnit(new Military(Position));
        }

        public bool IsNewMilitaryActive() {
            // TODO
            return true;
        }
    }
}
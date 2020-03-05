using Actions;
using Units;
using UnityEngine;

namespace Tiles {
    public class BarrackTile : BuildingTile {
        private const string BarrackTileName = "Barrack";
        private const int MilitaryCost = 10;

        public BarrackTile(Vector2Int position) : base(position, BarrackTileName) {
            AddAction(new PricedAction("new military", NewMilitary, IsNewMilitaryActive,20));
        }

        public void NewMilitary() {
            UnitManager.Instance.SpawnUnit(new Military(Position));
        }

        public bool IsNewMilitaryActive() {
            var unitOrNull = UnitManager.Instance.GetUnit(Position);
            return unitOrNull == null;
        }

        public override string GetDescription() {
            return "Military building";
        }
    }
}
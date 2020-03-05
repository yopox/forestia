using Actions;
using Units;
using UnityEngine;

namespace Tiles {
    public class FireStationTile : BuildingTile {
        private const string FireStationTileName = "Fire Station";

        public FireStationTile(Vector2Int position) : base(position, FireStationTileName) {
            AddAction(new PricedAction("new firefighter", NewFirefighter, IsNewFirefighterActive,10));
        }

        public void NewFirefighter() {
            UnitManager.Instance.SpawnUnit(new Firefighter(Position));
            
        }

        public bool IsNewFirefighterActive() {
            var unitOrNull = UnitManager.Instance.GetUnit(Position);
            return unitOrNull == null;
        }

        public override string GetDescription() {
            return "Fire station building";
        }
    }
}
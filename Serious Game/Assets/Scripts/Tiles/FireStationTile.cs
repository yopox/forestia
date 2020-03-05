using Actions;
using Units;
using UnityEngine;

namespace Tiles {
    public class FireStationTile : BuildingTile {
        private const string FireStationTileName = "Fire Station";
        private const int FirefighterCost = 10;

        public FireStationTile(Vector2Int position) : base(position, FireStationTileName) {
            AddAction(new PricedAction("new firefighter", NewFirefighter, IsNewFirefighterActive,FirefighterCost));
        }

        public void NewFirefighter() {
            GameState.Instance.money.Value -= FirefighterCost;
            GameState.Instance.UpdateTexts();
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
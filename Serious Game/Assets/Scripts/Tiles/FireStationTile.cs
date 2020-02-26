using Units;
using UnityEngine;

namespace Tiles {
    public class FireStationTile : BuildingTile {
        private const string FireStationTileName = "Fire Station";

        protected FireStationTile(Vector2Int position) : base(position, FireStationTileName) {
            AddAction(new TileAction("new firefighter", NewFirefighter, IsNewFirefighterActive));
        }

        public void NewFirefighter() {
            UnitManager.Instance.SpawnUnit(new Firefighter(Position));
        }

        public bool IsNewFirefighterActive() {
            var unitOrNull = UnitManager.Instance.GetUnit(Position);
            return unitOrNull == null;
        }
    }
}
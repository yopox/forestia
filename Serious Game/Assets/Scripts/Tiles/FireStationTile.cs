using Units;
using UnityEngine;

namespace Tiles {
    public abstract class FireStationTile : BuildingTile {
        private const string FireStationTileName = "Fire Station";

        protected FireStationTile(Vector2Int position) : base(position, FireStationTileName) {
            AddAction(new TileAction("new firefighter", NewFirefighter));
        }

        public void NewFirefighter() {
            UnitManager.Instance.SpawnUnit(new Firefighter(Position));
        }
    }
}
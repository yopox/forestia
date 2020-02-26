using System.Linq;
using UnityEngine;

namespace Tiles {
    public abstract class AbstractTile {
        public int Level { get; set; }
        public Vector2Int Position { get; }
        public string Name { get; }
        public TileAction[] Actions { get; }

        protected AbstractTile(Vector2Int position, string name) {
            Level = 1;
            Position = position;
            Name = name;
            Actions = new TileAction[] { };
        }

        protected void AddAction(TileAction tileAction) {
            Actions.Append(tileAction);
        }
    }
}
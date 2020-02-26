using System.Linq;
using UnityEngine;

namespace Tiles {
    public abstract class Tile {
        public int Level { get; }
        public Vector2Int Position { get; }
        public string Name { get; }
        public Action[] Actions { get; }

        protected Tile(Vector2Int position, string name) {
            Level = 1;
            Position = position;
            Name = name;
            Actions = new Action[] {};
        }
        
        protected void AddAction(Action action) {
            Actions.Append(action);
        }
    }
}
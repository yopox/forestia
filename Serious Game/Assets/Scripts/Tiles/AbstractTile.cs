using System.Collections.Generic;
using System.Linq;
using Actions;
using UnityEngine;

namespace Tiles {
    public abstract class AbstractTile {
        public int Level { get; set; }
        public Vector2Int Position { get; }
        public string Name { get; }
        public IEnumerable<Action> Actions { get; private set; }
        public abstract string GetDescription();

        protected AbstractTile(Vector2Int position, string name) {
            Level = 1;
            Position = position;
            Name = name;
            Actions = new Action[] { };
        }

        protected void AddAction(Action action) {
            Actions = Actions.Append(action);
        }
    }    
}
using System.Linq;
using UnityEngine;

namespace Units {
    public abstract class Unit {
        protected Unit(Vector2Int position) {
            Position = position;
            CanMove = true;
        }

        /* General attributes */
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract int Speed { get; }
        public abstract bool Friendly { get; }
        public abstract bool CPU { get; }
        public UnitAction[] Actions { get; }

        /* Gameplay attributes */
        public Vector2Int Position { get; }
        public bool CanMove { get; }

        /// <summary>
        /// Called when a unit is selected.
        /// </summary>
        public void Select() {
            // TODO: Show information

            // TODO: Show movements range

            // TODO: Show actions
        }
        
        protected void AddAction(UnitAction unitAction) {
            Actions.Append(unitAction);
        }
    }
}
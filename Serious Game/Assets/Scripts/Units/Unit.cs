using System.Collections.Generic;
using System.Linq;
using Actions;
using UnityEngine;

namespace Units {
    public abstract class Unit {
        public GameObject obj;

        /* General attributes */
        public string Name { get; }
        public string Description { get; }
        public int ActionPoints { get; }
        public int CurrentActionPoints { get; set; }
        public bool Friendly { get; }
        public bool CPU { get; }

        protected Unit(Vector2Int position, string name, string description, int actionPoints, bool friendly,
            bool cpu) {
            Position = position;
            CanMove = true;
            Actions = new List<Action>();
            Name = name;
            Description = description;
            ActionPoints = actionPoints;
            Friendly = friendly;
            CPU = cpu;
            CurrentActionPoints = ActionPoints;
        }

        public abstract GameObject Prefab { get; }
        public List<Action> Actions { get; private set; }

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

        protected void AddAction(Action action) {
            action.Method = () => {
                CurrentActionPoints = 0;
                action.Method();
            };
            action.IsActionActive = () => CurrentActionPoints != 0 && action.IsActionActive();
            Actions.Add(action);
        }
    }
}
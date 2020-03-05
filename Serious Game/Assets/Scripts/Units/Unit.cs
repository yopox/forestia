using System;
using System.Collections.Generic;
using System.Linq;
using Actions;
using Tiles;
using UnityEngine;
using Action = Actions.Action;

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
            AddAction(new MoveAction(this));
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
        public Vector2Int Position { get; set; }
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
            Actions.Add(action);
        }

        public void RestoreCurrentActionPoints() {
            CurrentActionPoints = ActionPoints;
        }

        public bool MoveTo(AbstractTile destination) {
            var distanceX = Math.Abs(Position.x - destination.Position.x);
            var distanceY = Math.Abs(Position.y - destination.Position.y);
            var distance = distanceX + distanceY;
            if (distance > CurrentActionPoints) {
                // you do not have enough actionPoints to move
                return false;
            }

            // move authorize
            CurrentActionPoints -= distance; // remove points
            Position = new Vector2Int(destination.Position.x, destination.Position.y); // move unit
            obj.transform.position =
                ForestManager.Instance.forest.CellToWorld(
                    new Vector3Int(destination.Position.x, destination.Position.y, 0) +
                    ForestManager.Instance.forest.origin) +
                new Vector3((float) 16, (float) 16, 0
                );

            return true;
        }
    }
}
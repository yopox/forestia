using System;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Events {
    public abstract class Event {
        public string Name { get; }
        public string Description { get; }
        public Influence[] Influences { get; }

        protected Event(string name, string description) {
            this.Name = name;
            this.Description = description;
            Influences = new Influence[] { };
        }

        protected void AddInfluence(Influence influence) {
            Influences.Append(influence);
        }

        public void Perform() {
            foreach (var newEventInfluence in Influences) {
                newEventInfluence.Perform(GameState.Instance);
            }
        }

        /// <summary>
        /// When the event occurs, this function will spread it on some tiles
        /// </summary>
        public void Declare() {
        }
    }
}
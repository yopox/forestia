using System;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Events {
    public abstract class Event {
        public string Name { get; }
        public string Description { get; }
        public List<Influence> Influences { get; }

        protected Event(string name, string description) {
            Name = name;
            Description = description;
            Influences = new List<Influence>();
        }

        protected void AddInfluence(Influence influence) {
            Influences.Add(influence);
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
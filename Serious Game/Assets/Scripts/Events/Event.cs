using System;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Events {
    public abstract class Event {
        public string Name { get; }
        public string Description { get; }
        public Influence[] Influences { get;  }

        protected Event(string Name, string Description) {
            this.Name = Name;
            this.Description = Description;
            Influences = new Influence[]{};
        }

        protected void AddInfluence(Influence influence) {
            Influences.Append(influence);
        }
        
        /// <summary>
        /// When the event occurs, this function will spread it on some tiles
        /// </summary>
        public void Declare() {
        }

        /// <summary>
        /// When the event occurs, this function will modify the various game parameters. 
        /// </summary>
        public void InfluenceState() {
            
        }
    }
}
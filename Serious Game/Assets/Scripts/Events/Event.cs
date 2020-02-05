using System;
using System.Collections.Generic;
using Tiles;
using UnityEngine;

namespace Events {
    public abstract class Event {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract double Probability { get; }
        public abstract double CriminalityInfluence { get; }
        public abstract double BiodiversityInfluence { get; }
        public abstract double FameInfluence { get; }
        public abstract double MoneyInfluence { get; }
        public abstract double ScienceInfluence { get; }

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
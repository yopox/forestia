using GameVariables;
using Tiles;

namespace Events {
    public class GoldDiggersEvent : Event {
        public GoldDiggersEvent() : base("Illegal gold mining", "Illegal gold mining has led to acres of rainforest being destroyed.") {
            AddInfluence(new AbsoluteInfluence(typeof(Criminality), 10));
        }
    }
}
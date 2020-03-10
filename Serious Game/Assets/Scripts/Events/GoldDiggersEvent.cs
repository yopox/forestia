using GameVariables;
using Tiles;

namespace Events {
    public class GoldDiggersEvent : Event {
        public GoldDiggersEvent() : base("Gold Diggers raged", "Once again, some gold diggers raged. They should be stopped.") {
            AddInfluence(new AbsoluteInfluence(typeof(Criminality), 10)); // TODO
            // AddInfluence(new AbsoluteInfluence(typeof(Biodiversity), -10)); // TODO
        }
    }
}
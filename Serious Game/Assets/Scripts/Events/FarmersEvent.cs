using GameVariables;

namespace Events {
    public class FarmersEvent : Event {
        public FarmersEvent() : base("Farmers", "Farmers Event") { // TODO
            AddInfluence(new AbsoluteInfluence(typeof(Biodiversity), -10)); // TODO
        }
    }
}
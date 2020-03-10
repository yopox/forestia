using GameVariables;

namespace Events {
    public class NewSpeciesEvent : Event {
        public NewSpeciesEvent() : base("New species", "A new species as been discovered !") {
            AddInfluence(new AbsoluteInfluence(typeof(Biodiversity), 100)); // TODO
        }
    }
}
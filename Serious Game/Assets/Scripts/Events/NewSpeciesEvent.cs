using GameVariables;

namespace Events {
    public class NewSpeciesEvent : Event {
        public NewSpeciesEvent() : base("It's a parrot!", "A new species was discovered in Forestia.") {
            AddInfluence(new AbsoluteInfluence(typeof(Biodiversity), 100));
        }
    }
}
using GameVariables;

namespace Events {
    public class FarmersEvent : Event {
        public FarmersEvent() : base("Farmers deforested", "Farmers are deliberately starting blazes in their efforts to clear land for crops or livestock.") {
            AddInfluence(new AbsoluteInfluence(typeof(Biodiversity), -25));
        }
    }
}
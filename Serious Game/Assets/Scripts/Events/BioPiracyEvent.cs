using GameVariables;

namespace Events {
    public class BioPiracyEvent : Event {
        public BioPiracyEvent() : base("Bio piracy detected", "People were spotted stealing animals!\nI heard there was a huge demand for these tropical animals...") { // TODO
            AddInfluence(new AbsoluteInfluence(typeof(Biodiversity), -15));
        }
    }
}
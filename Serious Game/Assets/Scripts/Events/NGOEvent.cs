using GameVariables;

namespace Events {
    public class NgoEvent : Event {
        public NgoEvent(int money) : base("Stand for Forestia", $"A NGO gave you {money}$ to help you in saving the forest!") {
            AddInfluence(new AbsoluteInfluence(typeof(Money), money));
        }
    }
}
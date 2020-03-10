using GameVariables;

namespace Events {
    public class NgoEvent : Event {
        public NgoEvent(int money) : base("Gift", "A NGO gives you " + money + "$ to help you save the forest") {
            AddInfluence(new AbsoluteInfluence(typeof(Money), money));
        }
    }
}
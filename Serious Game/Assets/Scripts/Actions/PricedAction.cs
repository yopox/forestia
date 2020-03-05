using System;

namespace Actions {
    public class PricedAction : Action {
        public int Price { get; }

        public PricedAction(string label, System.Action method, Func<bool> isActionActive, int price) :
            base(label, method, IsPricedActionActive(isActionActive, price)) {
            Price = price;
        }
        
        public static Func<bool> IsPricedActionActive(Func<bool> isActionActive, int price) {
            return () => GameState.Instance.money.Value >= price && isActionActive();
        }
    }
}
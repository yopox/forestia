using System;
using GameVariables;

namespace Events {
    public class PercentageInfluence : Influence {
        private readonly int _value;

        public PercentageInfluence(Type gameVariableType, int value) : base(gameVariableType, BuildValue(value)) {
            _value = value;
        }

        private static string BuildValue(int value) {
            string toDisplay;
            if (value < 0) {
                toDisplay = "- " + (-value);
            } else {
                toDisplay = "+ " + value;
            }

            return toDisplay + "%";
        }

        public override void Perform(GameState state) {
            if (GameVariableType == typeof(Biodiversity)) {
                state.biodiversity.Value *= (1 + (_value / 100));
            } else if (GameVariableType == typeof(Criminality)) {
                state.criminality.Value *= (1 + (_value / 100));
            } else if (GameVariableType == typeof(Fame)) {
                state.fame.Value *= (1 + (_value / 100));
            } else if (GameVariableType == typeof(Money)) {
                state.money.Value *= (1 + (_value / 100));
            } else if (GameVariableType == typeof(Science)) {
                state.science.Value *= (1 + (_value / 100));
            }
        }
    }
}
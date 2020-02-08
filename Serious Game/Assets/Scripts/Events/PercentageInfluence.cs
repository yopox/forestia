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
            if (GameVariableType == typeof(BiodiversityGameVariable)) {
                state.BiodiversityPoints.Value *= (1 + (_value / 100));
            } else if (GameVariableType == typeof(CriminalityGameVariable)) {
                state.CriminalityPoints.Value *= (1 + (_value / 100));
            } else if (GameVariableType == typeof(FameGameVariable)) {
                state.Fame.Value *= (1 + (_value / 100));
            } else if (GameVariableType == typeof(MoneyGameVariable)) {
                state.Money.Value *= (1 + (_value / 100));
            } else if (GameVariableType == typeof(ScienceGameVariable)) {
                state.SciencePoints.Value *= (1 + (_value / 100));
            }
        }
    }
}
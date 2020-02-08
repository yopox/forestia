using System;
using GameVariables;

namespace Events {
    public class AbsoluteInfluence : Influence {
        private readonly int _value;

        public AbsoluteInfluence(Type gameVariableType, int value) : base(gameVariableType, BuildValue(value)) {
            _value = value;
        }

        private static string BuildValue(int value) {
            string toDisplay;
            if (value < 0) {
                toDisplay = "- " + (-value);
            } else {
                toDisplay = "+ " + value;
            }

            return toDisplay;
        }

        public override void Perform(GameState state) {
            if (GameVariableType == typeof(BiodiversityGameVariable)) {
                state.BiodiversityPoints.Value += _value;
            } else if (GameVariableType == typeof(CriminalityGameVariable)) {
                state.CriminalityPoints.Value += _value;
            } else if (GameVariableType == typeof(FameGameVariable)) {
                state.Fame.Value += _value;
            } else if (GameVariableType == typeof(MoneyGameVariable)) {
                state.Money.Value += _value;
            } else if (GameVariableType == typeof(ScienceGameVariable)) {
                state.SciencePoints.Value += _value;
            }
        }
    }
}
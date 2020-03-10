using System;
using GameVariables;
using UnityEngine;

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
            if (GameVariableType == typeof(Biodiversity)) {
                state.biodiversity.Value += _value;
            } else if (GameVariableType == typeof(Criminality)) {
                state.criminality.Value += _value;
            } else if (GameVariableType == typeof(Fame)) {
                state.fame.Value += _value;
            } else if (GameVariableType == typeof(Money)) {
                state.money.Value += _value;
            } else if (GameVariableType == typeof(Science)) {
                state.science.Value += _value;
            }
        }
    }
}
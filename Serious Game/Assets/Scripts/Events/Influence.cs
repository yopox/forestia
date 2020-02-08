using System;
using GameVariables;

namespace Events {
    public abstract class Influence {
        protected readonly Type GameVariableType;
        private string _value;

        protected Influence(Type gameVariableType, string value) {
            GameVariableType = gameVariableType;
            _value = value;
        }

        public abstract void Perform(GameState state);
    }
}
using System;
using Units;

namespace Actions {
    public class DefaultUnitAction : Action {

        public DefaultUnitAction(string label, System.Action method, Func<bool> isActionActive) : base(label, method, isActionActive) {
        }
    }
}
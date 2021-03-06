using System;
using Units;

namespace Actions {
    public class MoveAction : Action {

        public MoveAction(Unit unit) : base("Move", MoveMethod(), IsMoveActionActive(unit)) {
        }

        public static System.Action MoveMethod() {
            return () => {
                GameManager.Instance.MoveAction();
            };
        }

        public static Func<bool> IsMoveActionActive(Unit unit) {
            return () => unit.CurrentActionPoints > 0;
        }
    }
}
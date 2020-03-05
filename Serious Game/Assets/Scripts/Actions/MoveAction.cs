using System;
using Units;

namespace Actions {
    public class MoveAction : Action {
        public int Price { get; }

        public MoveAction() : base("Move", MoveMethod(), IsMoveActionActive()) {
        }

        public static System.Action MoveMethod() {
            return () => GameManager.Instance.MoveAction();
        }

        public static Func<bool> IsMoveActionActive() {
            return () => true;
        }
    }
}
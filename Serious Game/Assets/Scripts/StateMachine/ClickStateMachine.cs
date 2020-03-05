namespace StateMachine {
    public enum ClickState {
        Forest,
        InGameMenu,
        MoveUnit,
        DailyDigest,
    }

    public class ClickStateMachine {
        public ClickState state { get; set; }

        public ClickStateMachine() {
            state = ClickState.DailyDigest;
        }

        public void MoveAction() {
            if (state == ClickState.Forest) {
                state = ClickState.MoveUnit;
            }
        }

        public void UnitMoved() {
            if (state == ClickState.MoveUnit) {
                state = ClickState.Forest;
            }
        }

        public void ReturnToGame() {
            if (state == ClickState.InGameMenu) {
                state = ClickState.Forest;
            }
        }

        public void BurgerClick() {
            if (state == ClickState.Forest || state == ClickState.MoveUnit) {
                state = ClickState.InGameMenu;
            }
        }

        public void NewTurn() {
            if (state == ClickState.Forest) {
                state = ClickState.DailyDigest;
                DailyDigestManager.Instance.dailyDigest.SetActive(true);
            }
        }

        public void Dismiss() {
            if (state == ClickState.DailyDigest) {
                state = ClickState.Forest;
                DailyDigestManager.Instance.dailyDigest.SetActive(false);

            }
        }
    }
}
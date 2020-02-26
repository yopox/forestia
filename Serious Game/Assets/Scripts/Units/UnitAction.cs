namespace Units {
    public delegate void ActionMethod();
    public delegate bool IsActionActive();

    public class UnitAction {
        public string label { get; }
        public ActionMethod method { get; }
        public IsActionActive isActionActive { get; }

        public UnitAction(string label, ActionMethod method, IsActionActive isActionActive) {
            this.label = label;
            this.method = method;
            this.isActionActive = isActionActive;
        }
    }
}
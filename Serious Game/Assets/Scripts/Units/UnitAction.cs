namespace Units {
    public delegate void ActionMethod();

    public class UnitAction {
        public string label { get; }
        public ActionMethod method { get; }

        public UnitAction(string label, ActionMethod method) {
            this.label = label;
            this.method = method;
        }
    }
}
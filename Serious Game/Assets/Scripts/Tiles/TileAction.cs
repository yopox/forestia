namespace Tiles {
    public delegate void ActionMethod();

    public class Action {
        public string label { get; }
        public ActionMethod method { get; }

        public Action(string label, ActionMethod method) {
            this.label = label;
            this.method = method;
        }
    }
}
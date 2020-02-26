namespace Tiles {
    public delegate void ActionMethod();
    public delegate bool IsActionActive();

    public class TileAction {
        public string label { get; }
        public ActionMethod method { get; }
        public IsActionActive isActionActive { get; }

        public TileAction(string label, ActionMethod method, IsActionActive isActionActive) {
            this.label = label;
            this.method = method;
            this.isActionActive = isActionActive;
        }
    }
}
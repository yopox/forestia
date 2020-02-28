namespace Tiles {
    public delegate void ActionMethod();

    public delegate bool IsActionActive();

    public class TileAction {
        public string Label { get; }
        public ActionMethod Method { get; }
        public IsActionActive IsActionActive { get; }

        public TileAction(string label, ActionMethod method, IsActionActive isActionActive) {
            this.Label = label;
            this.Method = method;
            this.IsActionActive = isActionActive;
        }
    }
}
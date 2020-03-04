namespace Tiles {
    public delegate void ActionMethod();

    public delegate bool IsActionActive();

    public class TileAction {
        public string Label { get; }
        public ActionMethod Method { get; }
        public IsActionActive IsActionActive { get; }
        public int Price { get;  }

        public TileAction(string label, ActionMethod method, IsActionActive isActionActive, int price) {
            this.Label = label;
            this.Method = method;
            this.IsActionActive = isActionActive;
            this.Price = price;
        }
    }
}
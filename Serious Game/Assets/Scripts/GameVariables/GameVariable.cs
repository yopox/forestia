namespace GameVariables {
    
    public abstract class GameVariable {
        public string Label;
        public string Icon; // TODO path in string or icon class
        public int Value { get; set; }

        protected GameVariable(string label, string icon, int value) {
            Label = label;
            Icon = icon;
            Value = value;
        }
    }
}
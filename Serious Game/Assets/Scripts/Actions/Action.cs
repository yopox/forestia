namespace Actions {
    public abstract class Action {
        public string Label { get; }
        public System.Action Method { get; set; }
        public System.Func<bool> IsActionActive { get; set; }

        protected Action(string label, System.Action method, System.Func<bool> isActionActive) {
            Label = label;
            Method = method;
            IsActionActive = isActionActive;
        }
    }
}
namespace Actions {
    public abstract class Action {
        public string Label { get; }
        public System.Action Method { get; }
        public System.Func<bool> IsActionActive { get; }

        protected Action(string label, System.Action method, System.Func<bool> isActionActive) {
            Label = label;
            Method = method;
            IsActionActive = isActionActive;
        }
    }
}
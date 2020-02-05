namespace Events {
    public class Fire : Event {
        public override string Name => "Fire";
        public override string Description => "Fire Event";
        public override double Probability => 0;
        public override double CriminalityInfluence => 0;
        public override double BiodiversityInfluence => 0;
        public override double FameInfluence => 0;
        public override double MoneyInfluence => 0;
        public override double ScienceInfluence => 0;


    }
}
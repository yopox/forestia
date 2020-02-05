using Tiles;

namespace Events {
    public class GoldDiggers : Event {
        public override string Name => "Gold Diggers";
        public override string Description => "Gold Diggers Event";
        public override double Probability => 0;
        public override double CriminalityInfluence => 0;
        public override double BiodiversityInfluence => 0;
        public override double FameInfluence => 0;
        public override double MoneyInfluence => 0;
        public override double ScienceInfluence => 0;
    }
}
using GameVariables;
using Tiles;

namespace Events {
    public class FireEvent : Event {
        public FireEvent(Tile tile) : base("Fire", BuildDescription(tile)) {
            Influence influence = new AbsoluteInfluence(typeof(Fame),-5);
            AddInfluence(influence);
        }

        private static string BuildDescription(Tile tile) {
            return "Oh no ! A fire broke out on tile [" + tile.Position.x + ", " + tile.Position.y + "]";
        }
    }
}
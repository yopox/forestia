using GameVariables;
using Tiles;

namespace Events {
    public class FireEvent : Event {
        public FireEvent(AbstractTile abstractTile) : base("Fire", BuildDescription(abstractTile)) {
            Influence influence = new AbsoluteInfluence(typeof(Fame),-5);
            AddInfluence(influence);
        }

        private static string BuildDescription(AbstractTile abstractTile) {
            return "Oh no ! A fire broke out on tile [" + abstractTile.PositionX + ", " + abstractTile.PositionY + "]";
            
        }
    }
}
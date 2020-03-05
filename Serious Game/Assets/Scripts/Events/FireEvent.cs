using GameVariables;
using Tiles;

namespace Events {
    public class FireEvent : Event {
        public FireEvent(ForestTile forestTile) : base("It's getting hot", BuildDescription(forestTile)) {
            Influence influence = new AbsoluteInfluence(typeof(Fame),-5);
            AddInfluence(influence);
        }
        
        private static string BuildDescription(AbstractTile tile) {
            return "Oh no! A fire broke out on parcel [" + tile.Position.x + ", " + tile.Position.y + "]!";
        }
    }
}
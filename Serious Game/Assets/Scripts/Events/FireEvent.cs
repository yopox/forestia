using System;
using System.Collections.Generic;
using System.Linq;
using GameVariables;
using Tiles;

namespace Events {
    public class FireEvent : Event {
        public FireEvent(List<ForestTile> tiles) : base("It's getting hot!", BuildDescription(tiles)) {
            AddInfluence(new AbsoluteInfluence(typeof(Fame), -Util.FireFameDrop * tiles.Count));
            AddInfluence(new AbsoluteInfluence(typeof(Biodiversity), -tiles.Select(tile => tile.GetBiodiversityScore()).Sum()));
        }

        private static string BuildDescription(List<ForestTile> tiles) {
            tiles.ForEach(tile => tile.SetFire());
            var parcels = String.Join(" ; ", tiles.Select(tile => $"[{tile.Position.x}, {tile.Position.y}]"));
            var parcelText = tiles.Count > 1 ? "parcels" : "parcel";
            return $"Fire broke out on {parcelText} {parcels}.";
        }
    }
}
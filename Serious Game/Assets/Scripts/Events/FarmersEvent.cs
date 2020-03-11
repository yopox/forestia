using System.Linq;
using GameVariables;
using Tiles;
using UnityEngine;

namespace Events {
    public class FarmersEvent : Event {
        public FarmersEvent() : base("Farmers caused deforestation",
            "Farmers are deliberately starting blazes in their efforts to clear land for crops or livestock.") {
            AddInfluence(new AbsoluteInfluence(typeof(Biodiversity), -25));

            for (var y = 0; y < ForestManager.Instance.forest.size.y; y++) {
                for (var x = 0; x < ForestManager.Instance.forest.size.x; x++) {
                    var tile = ForestManager.Instance.GetTile(new Vector2Int(x, y));
                    if (tile.GetType().FullName != "Tiles.ForestTile") {
                        continue;
                    }
                    
                    var fT = (ForestTile) tile;

                    if (!fT.OnFire) {
                        // Fire propagation
                        var neighbors = ForestManager.Instance.GetNeighbors(fT);
                        var farmFields = neighbors.Where(t => {
                            if (t.GetType() != typeof(FarmFieldTile)) return false;
                            return true;
                        }).ToList();

                        if (farmFields.Count > 0 && Random.Range(0f, 1f) < Util.FarmersFireProbability) {
                            fT.SetFire();
                        }
                    }

                }
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Events;
using Tiles;
using UnityEngine;
using Event = Events.Event;

/// <summary>
/// EventManager generates random events.
/// </summary>
public class EventManager : MonoBehaviour {
    private static EventManager _instance;

    public static EventManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<EventManager>();
            return _instance;
        }
    }

    /// <summary>
    /// Returns a new <c>DayEvent</c>.
    /// </summary>
    /// <returns>A <c>DayEvent</c>, or <value>DayEvent.None</value> according to <value>EventProbability</value>.</returns>
    public static List<Event> NewDayEvents() {
        var events = new List<Event>();

        // Fire event

        var tilesOnFire = new List<ForestTile>();
        for (var y = 0; y < ForestManager.Instance.forest.size.y; y++) {
            for (var x = 0; x < ForestManager.Instance.forest.size.x; x++) {
                var tile = ForestManager.Instance.GetTile(new Vector2Int(x, y)); // for each tile on the map
                if (tile.GetType().FullName != "Tiles.ForestTile") {
                    continue;
                }

                var fT = (ForestTile) tile;
                
                if (fT.OnFire) {
                    // Fire propagation
                    var neighbors = ForestManager.Instance.GetNeighbors(fT);
                    var forestsNotOnFire = neighbors.Where(t => {
                        if (t.GetType() != typeof(ForestTile)) return false;
                        return !((ForestTile) t).OnFire;
                    }).ToList();

                    foreach (var tmpNeighbor in forestsNotOnFire) {
                        if (Random.Range(0f, 1f) < Util.FirePropagationProba) {
                            var tmpForestNeighbor = (ForestTile) tmpNeighbor;
                            if (!tilesOnFire.Contains(tmpForestNeighbor)) tilesOnFire.Add(tmpForestNeighbor);
                        }
                    }
                }
                else {
                    // Spontaneous fire
                    if (Random.Range(0f, 1f) < Util.SpontaneousFireProba) {
                        if (!tilesOnFire.Contains(fT)) tilesOnFire.Add(fT);
                    }
                }
            }
        }

        if (tilesOnFire.Count > 0) {
            events.Add(new FireEvent(tilesOnFire));
        }

        // Global events

        if (Random.Range(0f, 1f) < Util.GlobalEventProba) {
            events.Add(new NgoEvent(Random.Range(10, 100)));
        }

        if (events.Count < 2 && Random.Range(0f, 1f) < Util.GlobalEventProba) {
            events.Add(new NewSpeciesEvent());
        }

        if (events.Count < 2 && Random.Range(0f, 1f) < Util.GlobalEventProba) {
            events.Add(new FarmersEvent());
        }

        if (events.Count < 2 && Random.Range(0f, 1f) < Util.GlobalEventProba) {
            events.Add(new GoldDiggersEvent());
        }

        events.ForEach(ev => ev.Perform());

        return events;
    }
}
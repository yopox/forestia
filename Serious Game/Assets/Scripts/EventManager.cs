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
        
        // global events

        if (Random.Range(0.0f, 100.0f) < 15) { // TODO
            var newEvent = new NgoEvent(Random.Range(10, 100)); // TODO
            newEvent.Perform();
            events.Add(newEvent);
        }
        
        if (Random.Range(0.0f, 100.0f) < 15) { // TODO
            var newEvent = new NewSpeciesEvent();
            newEvent.Perform();
            events.Add(newEvent);
        }
        
        if (Random.Range(0.0f, 100.0f) < 15) { // TODO
            var newEvent = new FarmersEvent();
            newEvent.Perform();
            events.Add(newEvent);
        }
        
        if (Random.Range(0.0f, 100.0f) < 15) { // TODO
            var newEvent = new GoldDiggersEvent();
            newEvent.Perform();
            events.Add(newEvent);
        }

        // events depending on current tile state
        
        for (var y = 0; y < ForestManager.Instance.forest.size.y; y++) {
            for (var x = 0; x < ForestManager.Instance.forest.size.x; x++) {

                if (events.Count == 2) {
                    return events;
                }
                
                var tile = ForestManager.Instance.GetTile(new Vector2Int(x, y)); // for each tile on the map
                
                switch (tile.GetType().FullName) {
                    case "Tiles.ForestTile":
                        var fT = (ForestTile) tile;
                        if (fT.OnFire) { // fire propagation
                            var neighbors = ForestManager.Instance.GetNeighbors(fT);
                            var forestsNotInFire = neighbors.Where(t => { // filter neighbor to be only leave forest tiles that are not already in fire
                                if (t.GetType() != typeof(ForestTile)) return false;
                                return !((ForestTile) t).OnFire;
                            }).ToList();
                            
                            foreach (var tmpNeighbor in forestsNotInFire) {
                                if (Random.Range(0.0f, 100.0f) < 10) { // TODO
                                    // Debug.Log("Adding Fire Event on neighbor");
                                    var tmpForestNeighbor = (ForestTile) tmpNeighbor;
                                    var newEvent = new FireEvent(tmpForestNeighbor);
                                    newEvent.Perform();
                                    events.Add(newEvent);
                                    tmpForestNeighbor.SetFire();
                                }
                            }
                        } else { // random spontaneous fire
                            if (Random.Range(0.0f, 100.0f) < 0.2f) { // TODO
                                // Debug.Log("Adding Fire Event");
                                var newEvent = new FireEvent(fT);
                                newEvent.Perform();
                                events.Add(newEvent);
                                fT.SetFire();
                            }
                        }
                        break;
                }
            }
        }

        return events;
    }
}
using System.Collections.Generic;
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

        for (var y = 0; y < ForestManager.Instance.forest.size.y; y++) {
            for (var x = 0; x < ForestManager.Instance.forest.size.x; x++) {
                var tile = ForestManager.Instance.GetTile(new Vector2Int(x, y));
                switch (tile.GetType().FullName) {
                    case "ForestTile":
                        var fT = (ForestTile) tile;

                        if (Random.Range(0, 1) < 0.05) { // TODO
                            var newEvent = new FireEvent(fT);
                            events.Add(newEvent);
                            fT.SetFire();
                            foreach (var newEventInfluence in newEvent.Influences) {
                                newEventInfluence.Perform(GameState.Instance);
                            }
                        }
                        
                        break;
                }
            }
        }

        return events;
    }
}
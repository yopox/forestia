using UnityEngine;

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

    public enum DayEvent {
        Fire,
        Farmers,
        GoldDiggers,
        Ngo,
        Policy,
        None
    }

    /// <summary>
    /// Returns a new <c>DayEvent</c>.
    /// </summary>
    /// <returns>A <c>DayEvent</c>, or <value>DayEvent.None</value> according to <value>EventProbability</value>.</returns>
    public static DayEvent NewDayEvent() {
        return Random.Range(0, 1) <= Util.EventProbability ? DayEvent.Fire : DayEvent.None;
    }
}
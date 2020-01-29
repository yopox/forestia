using UnityEngine;

/// <summary>
/// GameManager handles time, events, and the state of the game.
/// </summary>
public class GameManager : MonoBehaviour {
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }
    
    private int _biodiversityPoints;
    private int _popularityPoints;
    private int _criminalityPoints;

    /// <summary>
    /// Called at the beginning of a turn.
    /// </summary>
    public void NewTurn() {
        // Random events
        var dayEvent = EventManager.NewDayEvent();

        // Forest update

        // Points calculation
    }
}
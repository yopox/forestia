using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("New turn");
        GameState.Instance.round += 1;
        GameState.Instance.UpdateTexts();

        // Random events
        var dayEvents = EventManager.NewDayEvents();

        // Forest update
        ForestManager.Instance.Update();

        // Points calculation

        // New turn popup
        DailyDigestManager.Instance.UpdateWithEvents(dayEvents);
        DailyDigestManager.Instance.UpdateRound(GameState.Instance.round);

        // Ally CPU turn
        UnitManager.Instance.AllyCPUTurn();
    }

    public void EndTurn() {
        Debug.Log("End turn");
        // Display "Enemy turn"

        // Enemy turn
        UnitManager.Instance.EnemyTurn();

        // Start the next turn
        NewTurn();
    }

    private void Awake() {
        ForestManager.Instance.CreateForest();
        ForestManager.Instance.UpdateTileMap();
        NewTurn();
        //ForestManager.Instance.forest.ClearAllTiles();
    }
}
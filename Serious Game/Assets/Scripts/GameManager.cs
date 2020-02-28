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
        GameState.Instance.round += 1;
        GameState.Instance.UpdateTexts();

        // Random events
        var dayEvent = EventManager.NewDayEvent();

        // Forest update
        ForestManager.Instance.Update();

        // Points calculation

        // New turn popup

        // Ally CPU turn
        UnitManager.Instance.AllyCPUTurn();
    }

    public void EndTurn() {
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
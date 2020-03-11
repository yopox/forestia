using System;
using System.Collections.Generic;
using GameVariables;
using UnityEngine;
using UnityEngine.SceneManagement;
using Event = Events.Event;

public enum ClickState {
    Start,
    Forest,
    EnemyTurn,
    InGameMenu,
    MoveUnit,
    DailyDigest,
}

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

    public ClickState state { get; set; }

    public GameManager() {
        state = ClickState.Start; // init state
    }

    /// <summary>
    /// Called at the beginning of a turn.
    /// </summary>
    public void NewTurn() {
        var dayEvents = new List<Event>();
        if (state == ClickState.EnemyTurn) {
            state = ClickState.DailyDigest;
            Debug.Log("New turn");
            GameState.Instance.round += 1;
            GameState.Instance.UpdateTexts();

            // Random events
            dayEvents = EventManager.NewDayEvents();
            
            // Ally CPU turn
            UnitManager.Instance.AllyCPUTurn();
            DailyDigestManager.Instance.UpdateWithEvents(dayEvents);
            ForestManager.Instance.UpdateForestBiodiversityPoints();

        } else if (state == ClickState.Start) {
            state = ClickState.DailyDigest;
            Debug.Log("First turn");
            GameState.Instance.round = 1;
            GameState.Instance.UpdateTexts();
        }

        // Restore actionPoints on units
        UnitManager.Instance.RestoreActionPoints();

        // Update Forest Biodiversity
        
        // Points calculation
        GameState.Instance.biodiversity.Value += ForestManager.Instance.GetForestBiodiversityPoints() / Util.BiodiversityScale;
        
        // New turn popup
        DailyDigestManager.Instance.UpdateRound(GameState.Instance.round);
        
        // Updating changes on Tile Map
        ForestManager.Instance.UpdateTileMap();

        // Update scores
        GameState.Instance.UpdateTexts();
        
        DailyDigestManager.Instance.dailyDigest.SetActive(true);
    }

    public void EndTurn() {
        if (state == ClickState.Forest || state == ClickState.MoveUnit) {
            state = ClickState.EnemyTurn;
            Debug.Log("End turn");
            // Display "Enemy turn"

            // Enemy turn
            UnitManager.Instance.EnemyTurn();

            // Start the next turn
            NewTurn();
        }
    }

    public void MoveAction() {
        if (state == ClickState.Forest) {
            state = ClickState.MoveUnit;
            Debug.Log("Move action");
        } else if (state == ClickState.MoveUnit) {
            state = ClickState.Forest;
        }
    }

    public void UnitMoved() {
        if (state == ClickState.MoveUnit) {
            state = ClickState.Forest;
            Debug.Log("Unit moved");
        }
    }

    public void ReturnToGame() {
        if (state == ClickState.InGameMenu) {
            state = ClickState.Forest;
            Debug.Log("Return to game");
        }
    }

    public void BurgerClick() {
        if (state == ClickState.Forest || state == ClickState.MoveUnit) {
            Debug.Log("Burger click");
            state = ClickState.InGameMenu;
            MenuManager.Instance.OpenMenu();
        }
    }

    public void Dismiss() {
        if (state == ClickState.DailyDigest) {
            state = ClickState.Forest;
            Debug.Log("Dismiss");
        }
    }

    private void Awake() {
        ForestManager.Instance.CreateForest();
        ForestManager.Instance.UpdateTileMap();

        NewTurn();
        //ForestManager.Instance.forest.ClearAllTiles();
    }
}
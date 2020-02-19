using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Tile = Tiles.Tile;

/// <summary>
/// ForestManager contains information about the map.
/// </summary>
/// TODO: Structure containing the tiles
/// TODO: Fire propagation
public class ForestManager : MonoBehaviour {
    private static ForestManager _instance;
    public Tilemap forest;

    public static ForestManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<ForestManager>();
            return _instance;
        }
    }

    private Tile[,] _tiles;

    public ForestManager() {
        _tiles = new Tile[Util.GridHeight, Util.GridWidth];
    }

    /// <summary>
    /// Inits the forest.
    /// </summary>
    public void CreateForest() {
        Console.Out.Write(forest.size);
        //forest.ClearAllTiles();
    }

    public void Update() {
    }
}
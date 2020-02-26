using System;
using Tiles;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// ForestManager contains information about the map.
/// </summary>
/// TODO: Structure containing the tiles
/// TODO: Fire propagation
public class ForestManager : MonoBehaviour {
    private static ForestManager _instance;
    public Tilemap forest;
    public TileBase forestTile;
    public TileBase fieldTile;
    public TileBase fireTile;

    public static ForestManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<ForestManager>();
            return _instance;
        }
    }

    private AbstractTile[,] _tiles;

    public ForestManager() {
        _tiles = new AbstractTile[Util.GridHeight, Util.GridWidth];
    }

    /// <summary>
    /// Inits the forest.
    /// </summary>
    public void CreateForest() {
        Console.Out.Write(forest.size);
        //forest.ClearAllTiles();
        //Debug.Log(fire_tile.ge);
        var tile = forest.GetTile(forest.origin);
        forest.SetTile(forest.origin + new Vector3Int(2, 1, 0), fireTile);
    }

    public void Update() {
    }
}
using UnityEngine;
using Tiles;

/// <summary>
/// ForestManager contains information about the map.
/// </summary>
/// TODO: Structure containing the tiles
/// TODO: Fire propagation
public class ForestManager : MonoBehaviour {
    private static ForestManager _instance;

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
        for (var i = 0; i < Util.GridHeight; i++) {
            for (var j = 0; j < Util.GridWidth; j++) {
                // _tiles[i, j] = new Tile();
            }
        }
    }

    public void Update() {
    }
}
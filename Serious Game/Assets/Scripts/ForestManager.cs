using System;
using System.Collections.Generic;
using Tiles;
using Units;
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
    public TileBase riverTile;
    public TileBase barrackTile;
    public TileBase farmTile;
    public TileBase farmFieldTile;
    public TileBase fireStationTile;
    public TileBase labTile;
    public GameObject cursor;
    public GameObject unitCursor;


    private const string FOREST_TILE = "tile_forest";
    private const string FIELD_TILE = "tile_field";
    private const string FIRE_TILE = "tile_fire";
    private const string RIVER_TILE = "tile_river";
    private const string BARRACK_TILE = "tile_barrack";
    private const string FARM_TILE = "tile_farm";
    private const string FARM_FIELD_TILE = "tile_farmField";
    private const string FIRE_STATION_TILE = "tile_fireStation";
    private const string LAB_TILE = "tile_lab";

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

    public AbstractTile GetTile(Vector2Int position) {
        return _tiles[position.y, position.x];
    }

    /// <summary>
    /// Inits the forest.
    /// </summary>
    public void CreateForest() {
        unitCursor.SetActive(false);
        Debug.Log("Init forest of size " + forest.size);

        var size = forest.size;
        _tiles = new AbstractTile[size.y, size.x];

        for (var y = 0; y < size.y; y++) {
            for (var x = 0; x < size.x; x++) {
                switch (forest.GetTile(forest.origin + new Vector3Int(x, y, 0)).name) {
                    case FOREST_TILE:
                        _tiles[y, x] = new ForestTile(new Vector2Int(x, y));
                        _tiles[y, x].Level = 1;
                        break;
                    case FIELD_TILE:
                        _tiles[y, x] = new ForestTile(new Vector2Int(x, y));
                        _tiles[y, x].Level = 0;
                        break;
                    case FIRE_TILE:
                        _tiles[y, x] = new ForestTile(new Vector2Int(x, y));
                        ((ForestTile) _tiles[y, x]).SetFire();
                        break;
                    case RIVER_TILE:
                        _tiles[y, x] = new RiverTile(new Vector2Int(x, y));
                        break;
                    case BARRACK_TILE:
                        _tiles[y, x] = new BarrackTile(new Vector2Int(x, y));
                        break;
                    case FARM_TILE:
                        _tiles[y, x] = new FarmTile(new Vector2Int(x, y));
                        break;
                    case FARM_FIELD_TILE:
                        _tiles[y, x] = new FarmFieldTile(new Vector2Int(x, y));
                        break;
                    case FIRE_STATION_TILE:
                        _tiles[y, x] = new FireStationTile(new Vector2Int(x, y));
                        break;
                    case LAB_TILE:
                        _tiles[y, x] = new LaboratoryTile(new Vector2Int(x, y));
                        break;
                }
            }
        }
    }

    public void UpdateTileMap() {
        for (var y = 0; y < forest.size.y; y++) {
            for (var x = 0; x < forest.size.x; x++) {
                var position = forest.origin + new Vector3Int(x, y, 0);
                var displayed = forest.GetTile(position).name;
                var tile = _tiles[y, x];
                Debug.Log(tile.GetType().FullName);
                switch (tile.GetType().FullName) {
                    case "Tiles.ForestTile":
                        var fT = (ForestTile) tile;
                        if (fT.InFire && displayed != FIRE_TILE) {
                            Debug.Log("coucou");
                            forest.SetTile(position, fireTile);
                        }
                        else if (!fT.InFire && fT.Level == 0 && displayed != FIELD_TILE)
                            forest.SetTile(position, fieldTile);
                        else if (!fT.InFire && fT.Level == 1 && displayed != FOREST_TILE)
                            forest.SetTile(position, forestTile);
                        break;
                    case "Tiles.RiverTile":
                        if (displayed != RIVER_TILE) forest.SetTile(position, riverTile);
                        break;
                    case "Tiles.BarrackTile":
                        if (displayed != BARRACK_TILE) forest.SetTile(position, barrackTile);
                        break;
                    case "Tiles.FarmTile":
                        if (displayed != FARM_TILE) forest.SetTile(position, farmTile);
                        break;
                    case "Tiles.FarmFieldTile":
                        if (displayed != FARM_FIELD_TILE) forest.SetTile(position, farmFieldTile);
                        break;
                    case "Tiles.FireStationTile":
                        if (displayed != FIRE_STATION_TILE) forest.SetTile(position, fireStationTile);
                        break;
                    case "Tiles.LaboratoryTile":
                        if (displayed != LAB_TILE) forest.SetTile(position, labTile);
                        break;
                }
            }
        }

        // Cursor is set on origin tile, so updating the interactor accordingly
        InteractorManager.Instance.UpdateInteractorWithTile(_tiles[0, 0]);
    }

    public void Update() {
        if (!Input.GetMouseButtonDown(0)) {
            return; // a click should have been fired    
        }

        // ReSharper disable once PossibleNullReferenceException
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int origin = forest.origin;
        Vector3Int gridPos = forest.WorldToCell(mousePos) - origin;
        Vector3 newPositionOfCursor = forest.CellToWorld(gridPos + origin) +
                                      new Vector3((float) 16, (float) 16, 0);
        
        if (!forest.HasTile(gridPos + forest.origin)) {
            return; // click outside of the map
        }

        var positionClicked = new Vector2Int(gridPos.x, gridPos.y);
        
        // Forest mode
        if (GameManager.Instance.state == ClickState.Forest) {

            var unit = UnitManager.Instance.GetUnit(positionClicked);

            var unitOnTile = unit != null;
            var unitCursorOnTile = unitCursor.transform.position == newPositionOfCursor;
            var unitCursorIsActive = unitCursor.activeSelf;

            if (unitOnTile && (!unitCursorOnTile || !unitCursorIsActive)) {
                // if unit on tile and the unit cursor is either not on this tile or not currently selected 
                cursor.SetActive(false);
                unitCursor.SetActive(true);
                unitCursor.transform.position = newPositionOfCursor; // Move the cursor to the selected unit
                InteractorManager.Instance.UpdateInteractorWithUnit(unit); // Update the GUI with the selected unit
            } else {
                // should select tile instead of the unit on it
                cursor.SetActive(true);
                unitCursor.SetActive(false);
                cursor.transform.position = newPositionOfCursor; // Move the cursor to the selected tile
                InteractorManager.Instance.UpdateInteractorWithTile(_tiles[gridPos.y,
                    gridPos.x]); // Update the GUI with the selected tile
            }
        }
        // Move Mode
        else if (GameManager.Instance.state == ClickState.MoveUnit) {

            if (UnitManager.Instance.GetUnit(positionClicked) != null) {
                return; // cannot move there if a unit is already present
            }

            var unitToMovePosition = forest.WorldToCell(unitCursor.transform.position) - origin;
            var unitToMove = UnitManager.Instance.GetUnit(new Vector2Int(unitToMovePosition.x, unitToMovePosition.y));
            
            // try to move
            unitToMove.MoveTo(_tiles[gridPos.y, gridPos.x]);
        }
    }

    public List<AbstractTile> GetNeighbors(AbstractTile tile) {
        var neighbors = new List<AbstractTile>();

        if (tile.Position.x != 0) {
            // got a left neighbor
            neighbors.Add(GetTile(new Vector2Int(tile.Position.x - 1, tile.Position.y)));
        }

        if (tile.Position.x != forest.size.x - 1) {
            // got a right neighbor
            neighbors.Add(GetTile(new Vector2Int(tile.Position.x + 1, tile.Position.y)));
        }

        if (tile.Position.y != 0) {
            // got a bottom neighbor
            neighbors.Add(GetTile(new Vector2Int(tile.Position.x, tile.Position.y - 1)));
        }

        if (tile.Position.y != forest.size.y - 1) {
            // got a top neighbor
            neighbors.Add(GetTile(new Vector2Int(tile.Position.x, tile.Position.y + 1)));
        }

        return neighbors;
    }
}
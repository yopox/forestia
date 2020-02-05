using System.Collections.Generic;
using System.Linq;
using Units;
using UnityEngine;

/// <summary>
/// UnitManager manages the different units on the map.
/// </summary>
public class UnitManager : MonoBehaviour {
    private static UnitManager _instance;

    public static UnitManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<UnitManager>();
            return _instance;
        }
    }

    public List<Unit> units = new List<Unit>();

    public void SpawnUnit(Unit unit) {
        units.Add(unit);
    }

    public void KillUnit(Unit unit) {
        units.Remove(unit);
    }

    public void EnemyTurn() {
        foreach (var unit in units.Where(unit => !unit.Friendly)) {
            // CPU-controlled unit turn
        }
    }

    public void AllyCPUTurn() {
        foreach (var unit in units.Where(unit => unit.Friendly && unit.CPU)) {
            // CPU-controlled unit turn
        }
    }
}
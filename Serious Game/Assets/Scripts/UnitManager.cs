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
}
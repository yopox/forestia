using System;
using Tiles;
using UnityEngine;
using UnityEngine.UI;

public class InteractorManager : MonoBehaviour {
    private static InteractorManager _instance;
    public Text description;
    public Text type;
    public Button action1;
    public Text action1Text;
    public Button action2;
    public Text action2Text;
    public Button action3;
    public Text action3Text;
    public Button action4;
    public Text action4Text;

    public static InteractorManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<InteractorManager>();
            return _instance;
        }
    }

    public void UpdateInteractor(AbstractTile tile) {
        type.text = tile.Name.ToUpper();
        string newDescription;
        switch (tile.GetType().FullName) {
            case "Tiles.ForestTile":
                var fT = (ForestTile) tile;
                newDescription = "This is a Forest Tile";
                if (fT.InFire) {
                    newDescription += "\nThis tile is on fire !";
                };
                UpdateDescription(newDescription);
                break;
            case "Tiles.RiverTile":
                newDescription = "This is a River Tile";
                UpdateDescription(newDescription);
                break;
            case "Tiles.BarrackTile":
                newDescription = "This is a Barracks Tile";
                UpdateDescription(newDescription);
                break;
            case "Tiles.FarmTile":
                newDescription = "This is a Farm Tile";
                UpdateDescription(newDescription);
                break;
            case "Tiles.FarmFieldTile":
                newDescription = "This is a Farm Field Tile";
                UpdateDescription(newDescription);
                break;
            case "Tiles.FireStationTile":
                newDescription = "This is a Fire Station Tile";
                UpdateDescription(newDescription);
                break;
            case "Tiles.LaboratoryTile":
                newDescription = "This is a Lab Tile";
                UpdateDescription(newDescription);
                break;
        }
    }

    private void UpdateDescription(string newDescription) {
        description.text = newDescription;
    }

    private void UpdateActions() {
        return;
    }

    private void UpdateType(AbstractTile tile) {
        
    }
}
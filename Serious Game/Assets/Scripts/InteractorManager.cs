using System;
using Tiles;
using Units;
using UnityEngine;
using UnityEngine.UI;

public class InteractorManager : MonoBehaviour {
    private static InteractorManager _instance;
    public Text description;
    public Text type;
    public Button action1;
    public Text action1Text;
    private GameObject _action1Object;
    public Button action2;
    public Text action2Text;
    private GameObject _action2Object;
    public Button action3;
    public Text action3Text;
    private GameObject _action3Object;
    public Button action4;
    public Text action4Text;
    private GameObject _action4Object;


    public static InteractorManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<InteractorManager>();
            }
            return _instance;
        }
    }

    private void Awake() {
        // Init the associated objects with the actions, and put them to inactive by default until enabled later
        _action1Object = GameObject.Find("Action1");
        _action1Object.SetActive(false);
        action1Text.text = "";
        _action2Object = GameObject.Find("Action2");
        _action2Object.SetActive(false);
        action2Text.text = "";
        _action3Object = GameObject.Find("Action3");
        _action3Object.SetActive(false);
        action3Text.text = "";
        _action4Object = GameObject.Find("Action4");
        _action4Object.SetActive(false);
        action4Text.text = "";
    }

    public void UpdateInteractorWithTile(AbstractTile tile) {
        // Start by flushing the actions (setting them to inactive)
        _instance.FlushActions();
        
        // Update type
        type.text = tile.GetType().Name.ToUpper();
        
        //Update actions
        _instance.UpdateActionsWithTile(tile);
        
        // Tile specific updates
        string newDescription;
        
        switch (tile.GetType().FullName) {
            case "Tiles.ForestTile":
                var fT = (ForestTile) tile;
                newDescription = "This is a Forest Tile";
                if (fT.InFire) {
                    newDescription += "\nThis tile is on fire !";
                };
                _instance.UpdateDescription(newDescription);
                break;
            case "Tiles.RiverTile":
                newDescription = "This is a River Tile";
                _instance.UpdateDescription(newDescription);
                break;
            case "Tiles.BarrackTile":
                newDescription = "This is a Barracks Tile";
                _instance.UpdateDescription(newDescription);
                break;
            case "Tiles.FarmTile":
                newDescription = "This is a Farm Tile";
                _instance.UpdateDescription(newDescription);
                break;
            case "Tiles.FarmFieldTile":
                newDescription = "This is a Farm Field Tile";
                _instance.UpdateDescription(newDescription);
                break;
            case "Tiles.FireStationTile":
                newDescription = "This is a Fire Station Tile";
                _instance.UpdateDescription(newDescription);
                break;
            case "Tiles.LaboratoryTile":
                newDescription = "This is a Lab Tile";
                _instance.UpdateDescription(newDescription);
                break;
        }
    }

    public void UpdateInteractorWithUnit(Unit unit) {
        // Start by flushing the actions (setting them to inactive)
        _instance.FlushActions();
        
        // Update type
        type.text = unit.GetType().Name.ToUpper();
        
        //Update actions
        _instance.UpdateActionsWithUnit(unit);
        _instance.UpdateDescription(unit.Description);
    }

    
    private void UpdateDescription(string newDescription) {
        description.text = newDescription;
    }

    private void UpdateActionsWithTile(AbstractTile tile) {
        foreach (var action in tile.Actions) {
            // Iterating through the 4 actions
            var buttonId = 1;
            switch (buttonId) {
                case 1: 
                    _action1Object.SetActive(true);
                    action1.interactable = action.IsActionActive();
                    action1.onClick.AddListener(() => {
                        action.Method();
                        action1.interactable = action.IsActionActive();
                    });
                    action1Text.text = action.Label;
                    break;
                case 2:
                    _action2Object.SetActive(true);
                    action2.interactable = action.IsActionActive();
                    action2.onClick.AddListener(() => {
                        action.Method();
                        action2.interactable = action.IsActionActive();
                    });
                    action2Text.text = action.Label;
                    break;
                case 3:
                    _action3Object.SetActive(true);
                    action3.interactable = action.IsActionActive();
                    action3.onClick.AddListener(() => {
                        action.Method();
                        action3.interactable = action.IsActionActive();
                    });
                    action3Text.text = action.Label;
                    break;
                case 4:
                    _action4Object.SetActive(true);
                    action4.interactable = action.IsActionActive();
                    action4.onClick.AddListener(() => {
                        action.Method();
                        action4.interactable = action.IsActionActive();
                    });
                    action4Text.text = action.Label;
                    break;
            }
            buttonId += 1;
        }
    }
    
    private void UpdateActionsWithUnit(Unit unit) {
        foreach (var action in unit.Actions) {
            // Iterating through the 4 actions
            var buttonId = 1;
            switch (buttonId) {
                case 1: 
                    _action1Object.SetActive(true);
                    action1.interactable = action.IsActionActive();
                    action1.onClick.AddListener(() => {
                        action.Method();
                        action1.interactable = action.IsActionActive();
                    });
                    action1Text.text = action.Label;
                    break;
                case 2:
                    _action2Object.SetActive(true);
                    action2.interactable = action.IsActionActive();
                    action2.onClick.AddListener(() => {
                        action.Method();
                        action2.interactable = action.IsActionActive();
                    });
                    action2Text.text = action.Label;
                    break;
                case 3:
                    _action3Object.SetActive(true);
                    action3.interactable = action.IsActionActive();
                    action3.onClick.AddListener(() => {
                        action.Method();
                        action3.interactable = action.IsActionActive();
                    });
                    action3Text.text = action.Label;
                    break;
                case 4:
                    _action4Object.SetActive(true);
                    action4.interactable = action.IsActionActive();
                    action4.onClick.AddListener(() => {
                        action.Method();
                        action4.interactable = action.IsActionActive();
                    });
                    action4Text.text = action.Label;
                    break;
            }
            buttonId += 1;
        }
    }

    private void UpdateType(AbstractTile tile) {
        
    }

    private void FlushActions() {
        try {
            _action1Object.SetActive(false);
            action1Text.text = "";
            _action2Object.SetActive(false);
            action2Text.text = "";
            _action3Object.SetActive(false);
            action3Text.text = "";
            _action4Object.SetActive(false);
            action4Text.text = "";
        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
    }
}
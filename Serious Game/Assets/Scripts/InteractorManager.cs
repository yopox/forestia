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

    private void UpdateDescription(string newDescription) {
        description.text = newDescription;
    }

    public void UpdateActions() {
        return;
    }

    public void UpdateType(AbstractTile tile) {
        //tile.GetType();
        type.text = tile.Name.ToUpper();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    private static MenuController _instance;
    public static MenuController Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<MenuController>();
            return _instance;
        }
    }
    
    public GameObject menu;
    private static readonly int Open = Animator.StringToHash("open");

    public void OpenInformations() {
        
    }

    public void SaveAndQuit() {
        
    }

    public void OpenMenu() {
        menu.SetActive(true);
        menu.GetComponent<Animator>().SetBool(Open, true);
    }

    public void CloseMenu() {
        
    }
}

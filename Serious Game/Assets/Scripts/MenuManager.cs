using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    private static MenuManager _instance;
    public static MenuManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<MenuManager>();
            return _instance;
        }
    }
    
    public GameObject menu;
    private static readonly int Open = Animator.StringToHash("open");
    private static readonly int Close = Animator.StringToHash("close");

    public void OpenInformations() {
        
    }

    public void SaveAndQuit() {
        // TODO: Save
        Application.Quit();
    }

    public void OpenMenu() {
        menu.SetActive(true);
        menu.GetComponent<Animator>().SetBool(Close, false);
        menu.GetComponent<Animator>().SetBool(Open, true);
    }

    public void CloseMenu() {
        menu.GetComponent<Animator>().SetBool(Open, false);
        menu.GetComponent<Animator>().SetBool(Close, true);
        GameManager.Instance.ReturnToGame();
    }
}

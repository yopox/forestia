using GameVariables;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
    private static GameState _instance;

    public GameState() {
        criminality = new Criminality();
        biodiversity = new Biodiversity();
        fame = new Fame();
        money = new Money();
        science = new Science();
        round = 0;
    }

    public static GameState Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<GameState>();
            return _instance;
        }
    }

    public Text textRound;
    public Text textMoney;
    public Text textFame;
    public Text textBiodiversity;
    public Text textCriminality;
    public Text textScience;
    
    public Criminality criminality;
    public Biodiversity biodiversity;
    public Fame fame;
    public Money money;
    public Science science;
    public int round;

    public void UpdateTexts() {
        textRound.text = "ROUND " + round;
        textMoney.text = "$$$\n" + money.Value;
        textFame.text = "FAME\n" + fame.Value + "%";
        textBiodiversity.text = "BIO.\n" + biodiversity.Value;
        textCriminality.text = "CRI.\n" + criminality.Value;
        textScience.text = "SCI.\n" + science.Value;
    }
    
}
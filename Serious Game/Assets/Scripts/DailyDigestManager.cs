using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Event = Events.Event;

public class DailyDigestManager : MonoBehaviour {
    public GameObject dailyDigest;
    public Text headline1;
    public Text description1;
    public Text headline2;
    public Text description2;
    public Text ddExitButtonText;

    private static DailyDigestManager _instance;

    private static readonly int Close = Animator.StringToHash("close");
    private static readonly int Open = Animator.StringToHash("open");

    public static DailyDigestManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<DailyDigestManager>();
            return _instance;
        }
    }

    /// <summary>
    /// This function is called by the exit button on the scene to close de DailyDigest. 
    /// </summary>
    public void CloseDd() {
        dailyDigest.GetComponent<Animator>().SetBool(Open, false);
        dailyDigest.GetComponent<Animator>().SetBool(Close, true); 
        GameManager.Instance.Dismiss();
    }

    public void UpdateRound(int round) {
        ddExitButtonText.text = "Begin Round #" + round;
    }

    public void UpdateWithEvents(List<Event> dayEvents) {
        FlushEvents();
        if (dayEvents.Count > 0) {
            headline1.text = dayEvents[0].Name;
            description1.text = dayEvents[0].Description;
        }

        if (dayEvents.Count > 1) {
            headline2.text = dayEvents[1].Name;
            description2.text = dayEvents[1].Description;
        }
        dailyDigest.SetActive(true);
        dailyDigest.GetComponent<Animator>().SetBool(Open, true);
        dailyDigest.GetComponent<Animator>().SetBool(Close, false);
    }

    private void FlushEvents() {
        headline1.text = "Life goes on in Forestia";
        description1.text = "No events today !";
        headline2.text = "";
        description2.text = "";
    }
}
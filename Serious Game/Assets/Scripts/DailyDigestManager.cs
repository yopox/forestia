using System;
using System.Collections.Generic;
using UnityEngine;
using Event = Events.Event;

public class DailyDigestManager : MonoBehaviour {
        public GameObject dailyDigest;
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
        }

        public void UpdateWithEvents(List<Event> dayEvents) {
                foreach (var dayEvent in dayEvents) {
                        
                }
                
                dailyDigest.GetComponent<Animator>().SetBool(Open, true);
                dailyDigest.GetComponent<Animator>().SetBool(Close, false);
        }
        
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Event = Events.Event;

public class DailyDigestManager : MonoBehaviour {
        public GameObject dailyDigest;
        private static DailyDigestManager _instance;
        
        
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
                dailyDigest.SetActive(false);
        }

        public void UpdateWithEvents(List<Event> dayEvents) {
                foreach (var dayEvent in dayEvents) {
                        
                }
        }
}
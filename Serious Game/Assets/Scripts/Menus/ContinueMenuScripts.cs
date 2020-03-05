using UnityEngine;

namespace Menus {
    public class ContinueMenuScripts : MonoBehaviour {
        private static readonly int IsContinue = Animator.StringToHash("isContinue");

        public void Browse() {
            
        }

        public void Return() {
            if (Camera.main != null) {
                Camera cam = Camera.main;
                Animator animator = cam.gameObject.GetComponent<Animator>();
                animator.SetBool(IsContinue, false);
            }
            //FileStream fs = File.Open("Saves/saveFile.forest", FileMode.Open, FileAccess.Write, FileShare.None);
            Debug.Log("[Continue menu] Return button clicked");
        }

        public void Launch() {
            
        }
    }
}
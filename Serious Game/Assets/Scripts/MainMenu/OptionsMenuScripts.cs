using UnityEngine;

namespace MainMenu {
    public class OptionsMenuScripts : MonoBehaviour{
        private static readonly int IsOptions = Animator.StringToHash("isOptions");
        
        public void Return() {
            if (Camera.main != null) {
                Camera cam = Camera.main;
                Animator animator = cam.gameObject.GetComponent<Animator>();
                animator.SetBool(IsOptions, false);
            }
            Debug.Log("[Continue menu] Return button clicked");
        }
    }
}
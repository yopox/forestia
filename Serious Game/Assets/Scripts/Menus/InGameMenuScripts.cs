using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus {
    public class InGameMenuScripts : MonoBehaviour {
        public GameObject menu;
        public GameObject ForestControler;
        
        private static readonly int IsMenu = Animator.StringToHash("isMenu");

        public void SpawnMenu() {
            if (Camera.main != null) {
                Camera cam = Camera.main;
                Animator animator = cam.gameObject.GetComponent<Animator>();
                animator.SetBool(IsMenu, true);
            }
            
        }

        public void ReturnToGame() {
            if (Camera.main != null) {
                Camera cam = Camera.main;
                Animator animator = cam.gameObject.GetComponent<Animator>();
                animator.SetBool(IsMenu, false);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus {
    public class MainMenuScripts : MonoBehaviour {
        private GameState _state;
        private static readonly int IsContinue = Animator.StringToHash("isContinue");
        private static readonly int IsOptions = Animator.StringToHash("isOptions");


        public void NewGame() {
            _state = new GameState();
            Debug.Log("New Game button clicked");
            SceneManager.LoadScene("MainScene");
        }

        public void ContinueGame() {
            if (Camera.main != null) {
                Camera cam = Camera.main;
                Animator animator = cam.gameObject.GetComponent<Animator>();
                animator.SetBool(IsContinue, true);
            }
            //FileStream fs = File.Open("Saves/saveFile.forest", FileMode.Open, FileAccess.Write, FileShare.None);
            Debug.Log("[Main Menu] Continue button clicked");
        }
    
        public void Options() {
            if (Camera.main != null) {
                Camera cam = Camera.main;
                Animator animator = cam.gameObject.GetComponent<Animator>();
                animator.SetBool(IsOptions, true);
            }
            Debug.Log("[Main Menu] Options button clicked");
        }
    }
}

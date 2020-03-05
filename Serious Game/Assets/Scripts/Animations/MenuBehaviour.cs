using UnityEngine;

namespace Animations {
    public class MenuBehaviour : StateMachineBehaviour {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            MenuManager.Instance.menu.SetActive(false);
        }
    }
}
using UnityEngine;

namespace Animations {
    public class GlossaryBehaviour : StateMachineBehaviour {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            GlossaryManager.Instance.glossary.SetActive(false);
        }
    }
}
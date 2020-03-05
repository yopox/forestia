using UnityEngine;

namespace Units {
    public class Digger : Unit {
        public Digger(Vector2Int position) : base(position, "Digger", "Looks for gold.", 1, false, true) {
        }

        public override GameObject Prefab => UnitManager.Instance.digger;
    }
}
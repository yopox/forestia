using UnityEngine;

namespace Units {
    public class Activist : Unit {
        public Activist(Vector2Int position) : base(position, "Activist", "todo", 1, true, true) {
        }

        public override GameObject Prefab => UnitManager.Instance.activist;
    }
}
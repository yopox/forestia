using UnityEngine;

namespace Units {
    public class Military : Unit {
        public Military(Vector2Int position) : base(position, "Military", "Helps protecting the forest.", 2, true, false) {
        }

        public override GameObject Prefab => UnitManager.Instance.military;
    }
}
using UnityEngine;

namespace Units {
    public class Farmer : Unit {
        public Farmer(Vector2Int position) : base(position, "Farmer", "Need space.", 1, false, true) {
        }
        
        public override GameObject Prefab => UnitManager.Instance.farmer;
    }
}
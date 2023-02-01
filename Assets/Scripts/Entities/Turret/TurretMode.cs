using UnityEngine;

namespace Project
{
    // Todo: Refactor this later to a enum based system
    [RequireComponent(typeof(TurretScan))]
    public class TurretMode : MonoBehaviour
    {
        public virtual void Activate(Enemy target)
        {
            // Todo: Look and shoot at the enemy
        }
    }
}

using UnityEngine;

namespace Project
{
    // Todo: Refactor this later to a enum based system
    [RequireComponent(typeof(TurretScan))]
    public class TurretMode : MonoBehaviour
    {
        public Projectile ProjectilePrefab;

        public virtual void Activate(Enemy target)
        {
            transform.up = target.transform.position - transform.position;
            Instantiate(ProjectilePrefab, transform.position, transform.rotation);
        }
    }
}

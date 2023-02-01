using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Project
{
    public class TurretScan : MonoBehaviour
    {
        public float Range;

        public virtual Enemy Scan()
        {
            var colliders = Physics2D.OverlapCircleAll((Vector2)transform.position, Range);
            return SelectTarget(colliders);
        }

        public virtual Enemy SelectTarget(Collider2D[] colliders)
        {
            foreach (var col in colliders)
            {
                if (col.GetComponent<Enemy>() is { } enemy)
                {
                    return enemy;
                }
            }

            return null;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(transform.position, new Vector3(0, 0, 1), Range);
        }
    }
#endif

}

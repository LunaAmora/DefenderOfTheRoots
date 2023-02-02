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
            if (colliders.Length == 0) return null;
            return SelectTarget(colliders);
        }

        public virtual Enemy SelectTarget(Collider2D[] colliders)
        {
            Enemy target = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;

            foreach (var col in colliders)
            {
                if (col.GetComponent<Enemy>() is { } enemy)
                {
                    float dist = Vector3.Distance(col.gameObject.transform.position, currentPos);
                    if (dist < minDist)
                    {
                        target = enemy;
                        minDist = dist;
                    }
                }
            }

            return target;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class RootSpot : MonoBehaviour
    {
        [SerializeField] GameObject atualTurret;
        CircleCollider2D circleColl2d;

        private void Awake()
        {
            circleColl2d = GetComponent<CircleCollider2D>();
        }

        private void Start()
        {
            if (atualTurret)
            {
                ActivateCollision(false);
            }
        }

        void ActivateCollision(bool _b)
        {
            circleColl2d.enabled = _b;
        }

        public void AddTurretToSpot(GameObject _turret)
        {
            _turret.gameObject.transform.SetParent(transform);
            _turret.transform.position = this.transform.position;
            atualTurret = _turret;
            ActivateCollision(false);
        }

        public void RemoveTurretFromSpot(GameObject _turret)
        {
            atualTurret = null;
            _turret.gameObject.transform.SetParent(null);
            ActivateCollision(true);
        }

        public GameObject GetAtualTurretOnSpot()
        {
            return atualTurret;
        }
    }
}

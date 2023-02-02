using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class Storage_Turret : MonoBehaviour
    {
        int resourceQuantity;
        TurretUpgrade_UI turretUpgrade_UI;

        private void Awake()
        {
            turretUpgrade_UI = GameObject.Find("Canvas").transform.Find("TurretUpgrade_Painel").GetComponent<TurretUpgrade_UI>();
        }

        public void AddResource()
        {
            resourceQuantity++;
        }

        public void RemoveResource()
        {
            resourceQuantity--;
        }

        private void OnMouseEnter()
        {
            turretUpgrade_UI.OpenClosePainel(true, transform.parent.GetComponent<RootSpot>());
        }

        private void OnMouseExit()
        {
            turretUpgrade_UI.OpenClosePainel(false, null);
        }
    }
}
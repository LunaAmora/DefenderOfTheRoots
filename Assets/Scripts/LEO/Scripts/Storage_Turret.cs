using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class Storage_Turret : MonoBehaviour
    {
        int resourceQuantity;
        //NewTurret_UI turretUpgrade_UI;

        private void Awake()
        {
            //turretUpgrade_UI = GameObject.Find("Canvas").transform.Find("NewTurret_Painel").GetComponent<NewTurret_UI>();
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
            //turretUpgrade_UI.OpenClosePainel(true, this);
        }

        private void OnMouseExit()
        {
            //turretUpgrade_UI.OpenClosePainel(false, null);
        }


        public int GetAtualResourceQuantity()
        {
            return resourceQuantity;
        }

    }
}

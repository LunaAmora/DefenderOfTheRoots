using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project
{
    public class CraftingResources_UI : MonoBehaviour, IPointerDownHandler
    {
        NewTurret_UI newTurretUI;

        private void Awake()
        {
            newTurretUI = GetComponentInParent<NewTurret_UI>();
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            if (Globals.Instance.InputManager.GetAtualDraggable())
            {
                DraggableObject _atualDraggable = Globals.Instance.InputManager.GetAtualDraggable().GetComponent<DraggableObject>();

                if (_atualDraggable.GetDraggableType() == DraggableType.Resource)
                {
                    newTurretUI.AddResourceQuantity();
                    Destroy(_atualDraggable.gameObject);
                }
            }
        }
    }
}

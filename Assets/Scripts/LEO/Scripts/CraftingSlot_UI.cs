using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project
{
    public class CraftingSlot_UI : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            if (Globals.Instance.InputManager.GetAtualDraggable())
            {
                DraggableObject atualDraggable = Globals.Instance.InputManager.GetAtualDraggable().GetComponent<DraggableObject>();

                if (atualDraggable.GetDraggableType() == DraggableType.Turret)
                {
                    atualDraggable.transform.SetParent(this.transform);
                    atualDraggable.transform.position = transform.position;
                }
            }
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {

        }
    }
}



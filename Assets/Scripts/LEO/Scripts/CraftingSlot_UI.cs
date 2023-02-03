using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project
{
    public class CraftingSlot_UI : MonoBehaviour, IPointerDownHandler
    {
        NewTurret_UI newTurretUI;

        private void Awake()
        {
            newTurretUI = transform.parent.GetComponentInParent<NewTurret_UI>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Globals.Instance.InputManager.GetAtualDraggable() && !newTurretUI.GetAtualDraggableObjectLocked())
            {
                DraggableObject _atualDraggable = Globals.Instance.InputManager.GetAtualDraggable().GetComponent<DraggableObject>();

                if (_atualDraggable.GetDraggableType() == DraggableType.Turret)
                {
                    _atualDraggable.SetAtualDragState(DragState.Locked);
                    _atualDraggable.transform.SetParent(this.transform);
                    _atualDraggable.transform.position = transform.position;
                    newTurretUI.SetAtualDraggableObjectLocked(_atualDraggable);
                }
            }
            else if (newTurretUI.GetAtualDraggableObjectLocked())
            {
                newTurretUI.GetAtualDraggableObjectLocked().SetAtualDragState(DragState.Dragging);
                newTurretUI.GetAtualDraggableObjectLocked().transform.SetParent(null);
                newTurretUI.SetAtualDraggableObjectLocked(null);
            }
        }
        
    }
}



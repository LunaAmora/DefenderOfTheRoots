using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project
{
    public class DraggableObject : MonoBehaviour
    {
        [SerializeField] DraggableType draggableType;
        DragState atualDragState = DragState.Nulo;

        Transform spriteTransform;
        RootSpot atualRootSpot;
        Storage_Turret atualStorageTurret;


        private void Awake()
        {
            spriteTransform = transform.Find("Sprite");
        }
        private void Start()
        {
            if (draggableType == DraggableType.Turret)
            {
                if (transform.parent.GetComponent<RootSpot>())
                    atualRootSpot = transform.parent.GetComponent<RootSpot>();
            }
        }
        private void FixedUpdate()
        {
            Vector3 _pos = new Vector3();
            if (atualDragState == DragState.Snaped && atualRootSpot)
            {
                _pos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                transform.position = _pos;
                spriteTransform.position = atualRootSpot.transform.position;
            }
            else if (atualDragState == DragState.Dragging || atualDragState == DragState.Inside)
            {
                _pos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                transform.position = _pos;
                spriteTransform.position = transform.position;
            }
        }


        public DraggableType GetDraggableType()
        {
            return draggableType;
        }
        public DragState GetAtualDragState()
        {
            return atualDragState;
        }



        private void OnMouseDown()
        {
            atualDragState = DragState.Dragging;
            atualRootSpot.RemoveTurretToSpot(gameObject);
        }
        private void OnMouseUp()
        {
            if (atualDragState == DragState.Inside && atualStorageTurret)
            {
                atualStorageTurret.AddResource();
                Destroy(gameObject);
            }
            else if (atualRootSpot)
            {
                atualRootSpot.AddTurretToSpot(gameObject);
            }
            atualDragState = DragState.Nulo;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<RootSpot>() && draggableType == DraggableType.Turret)
            {
                if (!collision.GetComponent<RootSpot>().GetAtualTurretOnSpot())
                {
                    atualDragState = DragState.Snaped;
                    atualRootSpot = collision.GetComponent<RootSpot>();
                }
            }
            else if (collision.GetComponent<Storage_Turret>() && draggableType == DraggableType.Resource)
            {
                atualStorageTurret = collision.GetComponent<Storage_Turret>();
                atualDragState = DragState.Inside;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<RootSpot>() && draggableType == DraggableType.Turret)
            {
                atualDragState = DragState.Dragging;
                atualRootSpot = collision.GetComponent<RootSpot>();
            }
            else if (collision.GetComponent<Storage_Turret>() && draggableType == DraggableType.Resource)
            {
                atualStorageTurret = null;
                atualDragState = DragState.Dragging;
            }
        }


    }
}
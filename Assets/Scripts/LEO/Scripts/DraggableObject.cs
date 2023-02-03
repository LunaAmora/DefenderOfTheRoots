using UnityEngine;

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
            if (draggableType == DraggableType.Turret &&
                transform.parent?.GetComponent<RootSpot>() is { } rootSpot)
                atualRootSpot = rootSpot;
        }

        private void FixedUpdate()
        {
            Vector2 _pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (atualDragState == DragState.Dragging)
            {
                transform.position = _pos;
                spriteTransform.position = transform.position;
            }
            else if (atualDragState == DragState.Snaped)
            {
                transform.position = _pos;
                spriteTransform.position = atualRootSpot.transform.position;
            }
        }


        public DraggableType GetDraggableType()
        {
            return draggableType;
        }

        public void SetAtualDragState(DragState _dragState)
        {
            atualDragState = _dragState;
        }

        public DragState GetAtualDragState()
        {
            return atualDragState;
        }

        private void OnMouseDown()
        {
            switch (atualDragState, draggableType)
            {
                case (DragState.Nulo | DragState.Locked, _):
                    Globals.Instance.InputManager.SetAtualDraggable(gameObject);
                    atualRootSpot?.RemoveTurretFromSpot(gameObject);
                    atualDragState = DragState.Dragging;
                    break;

                case (DragState.Dragging, DraggableType.Resource) when atualStorageTurret:
                    atualStorageTurret.AddResource();
                    atualDragState = DragState.Nulo;
                    Destroy(gameObject);
                    break;

                case (DragState.Snaped, DraggableType.Turret) when atualRootSpot:
                    atualRootSpot.AddTurretToSpot(gameObject);
                    atualDragState = DragState.Locked;
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (draggableType)
            {
                case DraggableType.Turret when
                    (collision.GetComponent<RootSpot>() is { } rootSpot && !rootSpot?.GetAtualTurretOnSpot()):
                    atualDragState = DragState.Snaped;
                    atualRootSpot = rootSpot;
                    break;

                case DraggableType.Resource when collision.GetComponent<Storage_Turret>() is { } storageTurret:
                    atualStorageTurret = storageTurret;
                    atualDragState = DragState.Locked;
                    break;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            switch (draggableType)
            {
                case DraggableType.Turret when collision.GetComponent<RootSpot>() is { } rootSpot:
                    atualDragState = DragState.Dragging;
                    atualRootSpot = rootSpot;
                    break;

                case DraggableType.Resource when collision.GetComponent<Storage_Turret>():
                    atualStorageTurret = null;
                    atualDragState = DragState.Dragging;
                    break;
            }
        }
    }
}

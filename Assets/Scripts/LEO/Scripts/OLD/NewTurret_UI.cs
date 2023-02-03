using Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTurret_UI : MonoBehaviour
{
    [SerializeField] Transform craftingSlot;

    int resourceQuantity;
    DraggableObject atualDraggableObject = null;
    


    public void ButtonsSwitch(int i)
    {
        switch (i)
        {
            case 0:
                if (resourceQuantity >= 4)
                {
                    Destroy(atualDraggableObject);
                    Globals.Instance.Instantiator.InstantiateTurret(TurretType.Collector, craftingSlot.position);
                }
                break;
            case 1:
                if (resourceQuantity >= 2)
                {
                    Destroy(atualDraggableObject);
                    GameObject _GO = Globals.Instance.Instantiator.InstantiateTurret(TurretType.Generic, craftingSlot.position);
                    _GO.transform.SetParent(craftingSlot);
                }
                break;

            default:
                break;
        }
    }

    public void AddResourceQuantity()
    {
        resourceQuantity++;
    }

    public DraggableObject GetAtualDraggableObjectLocked()
    {
        return atualDraggableObject;
    }
    public void SetAtualDraggableObjectLocked(DraggableObject _draggable)
    {
        atualDraggableObject = _draggable;
    }
}

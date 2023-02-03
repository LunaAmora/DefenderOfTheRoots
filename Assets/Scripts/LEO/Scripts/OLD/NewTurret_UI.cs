using Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTurret_UI : MonoBehaviour
{
    int resourceQuantity;
    DraggableObject atualDraggableObject = null;


    CanvasGroup canvasGroup;
    Storage_Turret atualStorageTurret;
    


    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void ButtonsSwitch(int i)
    {
        switch (i)
        {
            case 0:
                if (atualStorageTurret.GetAtualResourceQuantity() >= 4)
                {
                    print("Collector");
                    Globals.Instance.Instantiator.InstantiateTurret(TurretType.Collector, atualStorageTurret.transform.position);
                    Destroy(gameObject);
                }
                break;
            case 1:
                if (atualStorageTurret.GetAtualResourceQuantity() >= 2)
                {
                    print("New Turret");
                    Globals.Instance.Instantiator.InstantiateTurret(TurretType.Generic, atualStorageTurret.transform.position);
                    Destroy(gameObject);
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

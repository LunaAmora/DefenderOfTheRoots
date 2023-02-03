using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class EnumTypes : MonoBehaviour { }

    public enum DraggableType
    {
        Resource, Turret
    }

    public enum TurretType
    {
        Collector, Generic
    }

    public enum DragState
    {
        Nulo, Dragging, Snaped, Locked
    }
}

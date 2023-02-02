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
        Collector, Generic, Machinegun, Sniper, Shotgun
    }

    public enum DragState
    {
        Nulo, Dragging, Snaped, Inside
    }
}

using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project
{
    public class G_InputManager : MonoBehaviour
    {
        bool b_isMouseOverUI = false;

        GameObject atualDraggable;


        private void Update()
        {
            b_isMouseOverUI = EventSystem.current.IsPointerOverGameObject();
        }


        public void SetAtualDraggable(GameObject _GO)
        {
            atualDraggable = _GO;
        }
        public GameObject GetAtualDraggable()
        {
            return atualDraggable;
        }
        public bool GetIsMouseOverUI()
        {
            return b_isMouseOverUI;
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class TurretUpgrade_UI : MonoBehaviour
    {
        CanvasGroup canvasGroup;
        RootSpot atualRootSpot;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            OpenClosePainel(false, null);
        }

        public void MovePainelToSpot(RootSpot _rootSpot)
        {
            atualRootSpot = _rootSpot;
            transform.position = new Vector3(atualRootSpot.transform.position.x, atualRootSpot.transform.position.y + 1, 0);
        }

        public void OpenClosePainel(bool _b, RootSpot _rootSpot)
        {
            if (_b)
            {
                if (_rootSpot)
                {
                    MovePainelToSpot(_rootSpot);
                    canvasGroup.alpha = 1;
                    canvasGroup.interactable = true;
                }
            }
            else
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
            }
        }
    }
}
using Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class Globals : MonoBehaviour
    {
        #region Singleton
        public static Globals Instance { get; private set; }


        void Awake()
        {
            Populate();

            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        public G_Instantiator Instantiator { get; private set; }
        public G_InputManager InputManager { get; private set; }

        void Populate()
        {
            Instantiator = GetComponentInChildren<G_Instantiator>();
            InputManager = GetComponentInChildren<G_InputManager>();
        }


        /*private static bool applicationIsQuitting = false;
        public void OnDestroy()
        {
            applicationIsQuitting = true;
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class SpawnMarker : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsUsed = false;

        private void Awake()
        {
            Hide();
        }

        public void Show()
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

        public void Hide()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
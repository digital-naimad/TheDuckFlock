using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class ResultsScreen : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SwitchVisibility(bool isVisible)
        {
            panel.SetActive(isVisible);
        }
    }
}

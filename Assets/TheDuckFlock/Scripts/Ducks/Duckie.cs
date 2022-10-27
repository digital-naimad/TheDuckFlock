using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{

    public class Duckie : Duck
    {
        [SerializeField] private Transform _toFollow;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            base.Update();

            Debug.Log("DUCKIE UPDATE");
        }
    }
}

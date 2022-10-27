using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class DucksMother : Duck
    {
       

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            base.Update();
            Debug.Log("DUCKS MOTHER UPDATE");
        }
    }
}


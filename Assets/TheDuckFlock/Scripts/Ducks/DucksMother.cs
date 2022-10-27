using DG.Tweening;
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
            Init();
        }

        // Update is called once per frame
        void Update()
        {
           base.Update();
           // Debug.Log("DUCKS MOTHER UPDATE");
           DoState();
        }

        private void Init()
        {
            currentDuckState = DuckState.LookingForFood;
            grainScopeRadius = 32f;
        }

        private void DoState()
        {
            switch (currentDuckState)
            {
                case DuckState.LookingForFood:
                    DoLookingForFood();

                    break;
                case DuckState.EatingGrain:

                    break;
                case DuckState.Lost:

                    break;
                case DuckState.Idling:
                default:
                    break;

            }
        }
    }
}


using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class DucksMother : DuckController
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
            currentDuckState = DuckState.Idling;

            duckRadius = 8f;
            grainScopeRadius = 32f;

            moveDuration = 3f;
            moveDistance = 2f;
        }

        private void DoState()
        {
            switch (currentDuckState)
            {
                case DuckState.LookingForFood:
                    DoLookingForFood();
                    break;
                case DuckState.EatingGrain:
                    DoEatGrain();
                    break;
                case DuckState.Lost:
                    DoLost();
                    break;
                case DuckState.Idling:
                default:
                    DoIdling(true);
                    break;

            }
        }
    }
}


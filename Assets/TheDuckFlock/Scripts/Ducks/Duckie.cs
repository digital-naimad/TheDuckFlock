using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{

    public class Duckie : DuckController
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

            //Debug.Log("DUCKIE UPDATE");
            DoState();
        }

        private void Init()
        {
            currentDuckState = DuckState.LookingForFood;

            duckRadius = 4f;
            grainScopeRadius = 16f;

            moveDuration = 1.5f;
            moveDistance = 1.5f;
        }

        private void DoState()
        {
            switch (currentDuckState)
            {
                case DuckState.FollowingParent:
                    DoFollowParent();
                    break;
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
                    DoIdling(false);
                    break;

            }
        }

        
    }
}

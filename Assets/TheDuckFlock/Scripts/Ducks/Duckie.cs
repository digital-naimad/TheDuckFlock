using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{

    public class Duckie : Duck
    {
        

        [SerializeField] private Transform _toFollow;

        [SerializeField] private float parentScopeRadius = 50f;

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
            grainScopeRadius = 16f;
        }

        private void DoState()
        {
            switch (currentDuckState)
            {
                case DuckState.FollowingParent:

                    break;
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

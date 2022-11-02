using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class DucksMother : DuckController
    {
        void Update()
        {
            base.Update();

            // Debug.Log("DUCKS MOTHER UPDATE");

            DoState();

            if (ScoreManager.Instance.WasGoalAchieved)
            {
                if (Vector3.Distance(transform.position, NestsManager.Instance.NestPosition) < NestsManager.Instance.NestScopeRadius)
                {
                    GameplayEventsManager.DispatchEvent(GameplayEvent.ReturnedToNest);
                }
            }
        }

        /// <summary>
        /// IPooledObject
        /// </summary>
        public override void OnSpawn()
        {
            //Debug.Log(name + " | OnSpawn()");
            Init();
        }

        private void DoState()
        {
            switch (currentDuckState)
            {
                // Food
                case DuckState.LookForFood:
                    DoLookForFood();
                    break;
                case DuckState.EatGrain:
                    DoEatGrain(DuckState.Idle);
                    break;

                // General ducks
                case DuckState.Newborn:
                    DoAnimateSpawn();
                    break;
                case DuckState.Lost:
                    DoAnimateLost(DoLost);
                    break;
                case DuckState.Idle:
                default:
                    DoIdle();
                    break;

            }
        }

        protected override void DoIdle()
        {
            //Debug.Log(name + " | DucksMother.DoIdling()");

            base.DoIdle();

            // CHECKS FOOD
            GrainController closestGrain = GrainManager.Instance.GetClosestGrain(transform.position);
            
            if (closestGrain != null)
            {
                float distance = Vector3.Distance(transform.position, closestGrain.transform.position);

                if (distance < grainScopeRadius) // && distance > 8f)
                {
                    currentDuckState = DuckState.LookForFood;
                }
            }
        }

        protected override void DoLost()
        {
            base.DoLost();

            if (!wasLostEventDispatched)
            {
                GameplayEventsManager.DispatchEvent(GameplayEvent.DucksMotherLost);
                wasLostEventDispatched = true;
            }
        }

        private void Init()
        {
            currentDuckState = DuckState.Newborn;

            fullScale = 1f;
            duckRadius = 8f;
            grainScopeRadius = 18*4;

            moveDuration = .25f;
            moveDistance = 2f;

            wasLostEventDispatched = false;
        }

        
    }
}


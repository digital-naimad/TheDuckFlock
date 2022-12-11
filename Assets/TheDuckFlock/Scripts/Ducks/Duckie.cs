
using UnityEngine;

namespace TheDuckFlock
{

    public class Duckie : DuckController
    {
        [SerializeField] protected float parentSearchRadius = 18*2f;
        [SerializeField] protected float parentFollowRadius = 18/2f;

        [SerializeField] protected Transform parentToFollow = null;

        private float DistanceToParent
        {
            get 
            { 
                return Vector3.Distance(transform.position, parentToFollow.position); 
            }
        }

        void Update()
        {
            base.Update();

            //Debug.Log("DUCKIE UPDATE");
            DoState();
        }

        /// <summary>
        /// IPooledObject
        /// </summary>
        public override void OnSpawn()
        {
            Init();
        }

        private void DoState()
        {
            switch (currentDuckState)
            {
                // Parent
                case DuckState.GoToParent:
                    DoGoToParent();
                    break;
                case DuckState.FollowParent:
                    DoFollowParent();
                    break;
                
                // Food
                case DuckState.LookForFood:
                    DoLookForFood(() =>
                    {
                        return DistanceToParent > parentFollowRadius;
                    });
                    break;
                case DuckState.EatGrain:
                    DoEatGrain(DuckState.GoToParent);
                    break;

                // General
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

        #region Duckie's States 
        protected override void DoIdle()
        {
            //Debug.Log(name + " | Duckie.DoIdling()");

            base.DoIdle();

            if (parentToFollow == null)
            {
                // Searching for a new parent
                DuckController closestDuck = FlockManager.Instance.GetClosestDuckController(transform.position, this);

                if (closestDuck != null)
                {
                    float distance = Vector3.Distance(transform.position, closestDuck.transform.position);

                    if (distance < parentSearchRadius)
                    {
                        currentDuckState = DuckState.GoToParent;
                    }
                }
            }
            else 
            {
                if (DistanceToParent <= parentFollowRadius) // parent is close enough to safely looking for a food
                {
                    currentDuckState = DuckState.LookForFood;
                }
                else // parent is too far, so duckie should find another one
                {
                    parentToFollow = null;
                    currentDuckState = DuckState.GoToParent;
                }
                
            }
        }

        protected override void DoLost()
        {
            base.DoLost();

            if (!wasLostEventDispatched)
            {
                GameplayEventsManager.DispatchEvent(GameplayEvent.DuckieLost);
                wasLostEventDispatched = true;
            }
        }

        private  void DoGoToParent()
        {
            Transform closestDuck = parentToFollow != null 
                ? parentToFollow 
                : FlockManager.Instance.GetClosestDuckController(transform.position, this).transform;

            if (closestDuck != null)
            {
                // Rotates the duck
                RotateToLookAt(closestDuck.transform.position);

                float distance = Vector3.Distance(transform.position, closestDuck.transform.position);

                if (distance > parentFollowRadius)
                {
                    Walk();
                }
                else // duckie is in the scope for following other duck
                {
                    parentToFollow = closestDuck.transform;
                    currentDuckState = DuckState.FollowParent;
                }
            }
        }

        private void DoFollowParent()
        {
            if (DistanceToParent <= parentFollowRadius)
            {
                currentDuckState = DuckState.Idle;
            }
            else
            {
                currentDuckState = DuckState.GoToParent;
            }
        }
        #endregion

        private void Init()
        {
            currentDuckState = DuckState.Newborn;

            fullScale = .5f;
            duckRadius = 4f;
            grainScopeRadius = 16f;

            moveDuration = .25f;
            moveDistance = .5f;

            wasLostEventDispatched = false;
        }
    }
}

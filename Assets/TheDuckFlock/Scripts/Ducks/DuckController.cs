using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheDuckFlock
{
    public class DuckController : MonoBehaviour
    {
        [SerializeField] protected DuckState currentDuckState = DuckState.Idling;

        [SerializeField] protected float duckRadius = 8f;
        [SerializeField] protected float grainScopeRadius = 30f;
        [SerializeField] protected float parentScopeRadius = 50f;

        [SerializeField] protected float rotationDuration = 1f;
        [SerializeField] protected float moveDuration = 2f;
        [SerializeField] protected float moveDistance = 2f;

        [SerializeField] protected Transform parentToFollow = null;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        protected void Update()
        {
            //Debug.Log("DUCK UPDATE");
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDucksMother"></param>
        protected void DoIdling(bool isDucksMother = false)
        {

            // CHECKS FOOD
            GrainController closestGrain = GrainManager.Instance.GetClosestGrainPile(transform.position);
            if (closestGrain != null)
            {
                float distance = Vector3.Distance(transform.position, closestGrain.transform.position);

                if (distance < grainScopeRadius && distance > 8f)
                {
                    currentDuckState = DuckState.LookingForFood;
                }
            }

            // CHECKS PARENT
            if (currentDuckState == DuckState.Idling) // state not changed
            {
                if (!isDucksMother) // Duck thing
                {
                    if (parentToFollow == null)
                    {
                        DuckController closestDuck = FlockManager.Instance.GetClosestDuckController(transform.position);

                        if (closestDuck != null)
                        {
                            currentDuckState = DuckState.FollowingParent;
                        }
                    }
                }
            }
        }


        protected void DoLookingForFood()
        {
            Debug.Log(name + " >> " + "DoLookingForFood()");

            GrainController closestGrain = GrainManager.Instance.GetClosestGrainPile(transform.position);
            if (closestGrain != null)
            {
                // Rotates the duck
                transform.DODynamicLookAt(closestGrain.transform.position, rotationDuration);

                float distance = Vector3.Distance(transform.position, closestGrain.transform.position);
                if (distance < grainScopeRadius)
                {
                    if (distance > 8f)
                    {
                        transform.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
                    }
                    else
                    {
                        currentDuckState = DuckState.EatingGrain;
                    }
                }
            }
        }

        protected void DoFollowParent()
        {
            if (parentToFollow == null)
            {
                DuckController closestDuck = FlockManager.Instance.GetClosestDuckController(transform.position);

                if (closestDuck != null)
                {
                    // Rotates the duck
                    transform.DODynamicLookAt(closestDuck.transform.position, rotationDuration);

                    float distance = Vector3.Distance(transform.position, closestDuck.transform.position);

                    if (distance < parentScopeRadius)
                    {
                        if (distance > 8f)
                        {
                            transform.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
                        }
                        else
                        {
                            parentToFollow = closestDuck.transform;
                            currentDuckState = DuckState.Idling;
                        }
                    }
                }
            }
            else
            {
                // Rotates the duck
                transform.DODynamicLookAt(parentToFollow.position, rotationDuration);

                float distance = Vector3.Distance(transform.position, parentToFollow.position);

                if (distance < parentScopeRadius)
                {
                    if (distance > 8f)
                    {
                        transform.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
                    }
                    else
                    {
                        currentDuckState = DuckState.Idling;
                    }
                }
            }
        }

        protected void DoEatGrain()
        {

        }

        protected void DoLost()
        {

        }


    }
}


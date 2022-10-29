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
        [SerializeField] protected float moveDuration = 1f;
        [SerializeField] protected float moveDistance = 2f;

        [SerializeField] protected Transform parentToFollow = null;

        [SerializeField] private float lostHeightThreshold = -3f;

        protected Rigidbody rigidbody
        {
            get 
            { 
                if (_rigidbody == null)
                {
                    _rigidbody = GetComponent<Rigidbody>();
                }
                return _rigidbody; 
            }
        }

        private Rigidbody _rigidbody;

        private Tween rotateTween = null;
        private Tween moveTween = null;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        protected void Update()
        {
            //Debug.Log("DUCK UPDATE");
            if (transform.position.y < lostHeightThreshold)
            {
                currentDuckState = DuckState.Lost;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDucksMother"></param>
        protected void DoIdling(bool isDucksMother = false)
        {

            // CHECKS FOOD
            GrainController closestGrain = GrainManager.Instance.GetClosestGrain(transform.position);
            if (closestGrain != null)
            {
                float distance = Vector3.Distance(transform.position, closestGrain.transform.position);

                if (distance < grainScopeRadius) // && distance > 8f)
                {
                    currentDuckState = DuckState.LookingForFood;
                }
            }

            /*
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
            */
        }

        

        protected void DoLookingForFood()
        {
            //Debug.Log(name + " >> " + "DoLookingForFood()");

            GrainController closestGrain = GrainManager.Instance.GetClosestGrain(transform.position);
            if (closestGrain != null)
            {
                // Rotates the duck
                rotateTween = transform.DODynamicLookAt(closestGrain.transform.position, rotationDuration);

                float distance = Vector3.Distance(transform.position, closestGrain.transform.position);
                if (distance < grainScopeRadius)
                {
                    if (distance > duckRadius)
                    {
                        if (moveTween != null && !moveTween.IsComplete())
                        {
                            moveTween.Kill();
                        }
                        moveTween = rigidbody.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
                       
                    }
                    else
                    {
                        currentDuckState = DuckState.EatingGrain;
                        //GrainManager.Instance.Peck(closestGrain);

                        //currentDuckState = DuckState.Idling;
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
                            //transform.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
                            rigidbody.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
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
                        rigidbody.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
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
            var closestGrain = GrainManager.Instance.GetClosestGrain(transform.position);
            if (closestGrain != null)
            {
                GrainManager.Instance.Peck(closestGrain);

                currentDuckState = DuckState.Idling;
            }
        }

        protected void DoLost()
        {
            if (rotateTween != null)
            {
                rotateTween.Complete();
                rotateTween = null;
            }

            if (moveTween != null)
            {
                moveTween.Complete();
                moveTween = null;
            }
        }

        protected void SwitchRigidbodyFreeze(bool isFreezed)
        {
            //rigidbody.freezeRotation = isFreezed;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

    }
}


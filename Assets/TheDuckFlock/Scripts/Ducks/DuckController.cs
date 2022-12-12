using DG.Tweening;
using System;
using UnityEngine;


namespace TheDuckFlock
{
    public abstract class DuckController : MonoBehaviour, IPooledObject
    {
        [SerializeField] protected DuckState currentDuckState = DuckState.Idle;

        [SerializeField] protected Transform parentToFollow = null;

        [SerializeField] protected float duckRadius = 8f;
        [SerializeField] protected float grainScopeRadius = 30f;

        [SerializeField] protected float fullScale;

        [SerializeField] protected float rotationDuration = 1f;
        [SerializeField] protected float moveDuration = 1f;
        [SerializeField] protected float moveDistance = 5f;

        [SerializeField] protected float spawnAnimationDuration = 1f;

        protected bool isMother = false;

        private bool isOnBridge = false;

        private bool isOnTrigger = false;
        private bool isOnCollision = false;

        public bool IsCandidateForParent
        {
            get { return parentToFollow != null; }
        }

        protected bool IsTimeToUpdate
        {
            get
            {
                if (Time.time >= nextTimeToStateUpdate)
                {
                    nextTimeToStateUpdate = Time.time + 1f / stateUpdateRate;
                    return true;
                }
                return false;
            }
        }

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

        protected Animator DuckAnimator
        {
            get
            {
                if (_duckAnimator == null)
                {
                    _duckAnimator = GetComponent<Animator>();
                }
                return _duckAnimator;
            }
        }

        protected bool wasLostEventDispatched = false;

        protected float stateUpdateRate = 15f;
        protected float nextTimeToStateUpdate = 0f;

        private Rigidbody _rigidbody;
        private Animator _duckAnimator;

        private Tween rotateTween = null;
        private Tween moveTween = null;


        private void OnEnable()
        {
            wasLostEventDispatched = false;
        }

        
        protected void Update()
        {
            //Debug.Log("DUCK UPDATE");

            if (transform.position.y < WorldManager.Instance.LostDuckThreshold)
            {
                currentDuckState = DuckState.Lost;
            }
        }



        public abstract void OnSpawn();

        

        #region Tween based animations

        protected void DoAnimateSpawn()
        {
            
            transform
                .DOScale(fullScale, spawnAnimationDuration)
                .From(0, true)
                .SetEase(Ease.OutBack)
                .OnComplete(() => 
                {
                    currentDuckState = DuckState.Idle;
                });
        }

        protected void DoAnimateLost(Action onCompleteCallback)
        {
            transform
                .DOScale(0, spawnAnimationDuration)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => onCompleteCallback());
        }

        #endregion

        protected virtual void DoIdle()
        {
            //Debug.Log(name + " | DuckController.DoIdling()");

            DuckAnimator.SetBool(nameof(DuckAnimation.idle), true);
        }

        protected void DoLookForFood(Func<bool> checkCallback = null)
        {
            //Debug.Log(name + " >> " + "DoLookingForFood()");

            GrainController closestGrain = GrainManager.Instance.GetClosestGrain(transform.position);

            if (closestGrain != null)
            {
                RotateToLookAt(closestGrain.transform.position);

                float distance = Vector3.Distance(transform.position, closestGrain.transform.position);
                if (distance < grainScopeRadius)
                {
                    if (distance > duckRadius)
                    {
                        Walk();
                    }
                    else
                    {
                        currentDuckState = DuckState.EatGrain;
                    }
                }
            }

            if (checkCallback != null)
            {

                if (checkCallback())
                {
                    currentDuckState = DuckState.GoToParent;
                }
            }
        }

        

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log(name + " | trigger enter " + other);

            isOnTrigger = true;
        }

        private void OnTriggerExit(Collider other)
        {
            //Debug.Log(name + " | trigger exit " + other);
            isOnTrigger = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            //Debug.Log(name + " | Collider exit " );
        }

        private void OnCollisionExit(Collision collision)
        {
           // Debug.Log(name + " | Collider exit " );
        }

        protected void Walk()
        {
            if (isMother && isOnTrigger)
            {
                //SoundManager.Instance.PlayMusic(SoundTag.RunningDuck);
            }

            //Debug.Log(name + " | Walk distance: " + moveDistance + " duration: " + moveDuration);
            DuckAnimator.SetBool(nameof(DuckAnimation.walk), true);

            if (moveTween == null)
            {
                moveTween = rigidbody.DOMove(transform.position + transform.forward * moveDistance, moveDuration)
                    //.SetEase(Ease.InQuint)
                    .OnComplete(
                    () =>
                    {
                        moveTween = null;
                    });
            }
            else
            {
                moveTween = rigidbody.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
            }


            
        }

        /*
        protected void Walk()
        {
            DuckAnimator.SetBool(nameof(DuckAnimation.walk), true);

            if (moveTween != null && !moveTween.IsComplete())
            {
                moveTween.Kill();
               
            }
            
                moveTween = rigidbody.DOMove(transform.position + transform.forward * moveDistance, moveDuration);
            
        }
        */

        protected void RotateToLookAt(Vector3 targetPosition)
        {
            // Rotates the duck
            rotateTween = transform.DODynamicLookAt(targetPosition, rotationDuration);
        }

        

        protected void DoEatGrain(DuckState stateAfterComplete)
        {
            var closestGrain = GrainManager.Instance.GetClosestGrain(transform.position);
            if (closestGrain != null)
            {
                GrainManager.Instance.Peck(closestGrain);

                currentDuckState = stateAfterComplete;
            }
        }

        protected virtual void DoLost()
        {
            DuckAnimator.SetBool(nameof(DuckAnimation.stun), true);

            if (rotateTween != null)
            {
                rotateTween.Kill(); //Complete();
                rotateTween = null;
            }

            if (moveTween != null)
            {
                moveTween.Kill(); //Complete();
                moveTween = null;
            }

            gameObject.SetActive(false);
        }

        protected void SwitchRigidbodyFreeze(bool isFreezed)
        {
            //rigidbody.freezeRotation = isFreezed;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

    }
}


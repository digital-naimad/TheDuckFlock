using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheDuckFlock
{
    public class Duck : MonoBehaviour
    {
        [SerializeField] protected DuckState currentDuckState = DuckState.Idling;

        [SerializeField] protected float rotationDuration = 1f;
        [SerializeField] protected float grainScopeRadius = 30f;
        [SerializeField] protected float movingSpeed = 2f;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        protected void Update()
        {
            //Debug.Log("DUCK UPDATE");
            
        }

        protected void DoLookingForFood()
        {
            Debug.Log(name + " >> " + "DoLookingForFood()");

            GrainController closestGrain = GrainManager.Instance.GetClosestGrainPile(transform.position);
            if (closestGrain != null)
            {
                // Rotates the duck
                transform.DODynamicLookAt(closestGrain.transform.position, rotationDuration);

                if (Vector3.Distance(transform.position, closestGrain.transform.position) < grainScopeRadius)
                {
                    
                }
            }
        }

    }
}


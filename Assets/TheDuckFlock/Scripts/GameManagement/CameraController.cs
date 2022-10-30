using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class CameraController : MonoSingleton<CameraController>
    {
        [SerializeField] private bool isFollowDucksMother = false;
        [SerializeField] private float moveDuration = 1f;
        [SerializeField] private Vector3 positionShift = new Vector3(-45, 0, -45);

        public bool IsFollowDucksMother { get { return isFollowDucksMother; } set { isFollowDucksMother = value; } }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isFollowDucksMother)
            {
                FollowDucksMother();
            }
        }

        private void FollowDucksMother()
        {

            Vector3 duckPosition = FlockManager.Instance.MotherPosition;
            
            gameObject.transform.DOMoveX(duckPosition.x + positionShift.x, moveDuration);
            gameObject.transform.DOMoveZ(duckPosition.z + positionShift.z, moveDuration);
        }

        
    }
}

using DG.Tweening;
using UnityEngine;

namespace TheDuckFlock
{
    public class CameraController : MonoSingleton<CameraController>
    {
       // [SerializeField] private bool _isFollowingDucksMother = false;
        [SerializeField] private float moveDuration = 1f;
        [SerializeField] private Vector3 positionShift = new Vector3(-45, 0, -45);

        private Vector3 lastMotherPosition = Vector3.zero;
        public bool IsFollowingDucksMother 
        { 
            get 
            {
                return FlockManager.Instance.MotherPosition != Vector3.zero; //_isFollowingDucksMother; 
            } 
            /*
            set 
            { 
                _isFollowingDucksMother = value;
            } 
            */
        }


        // Update is called once per frame
        void Update()
        {
            if (IsFollowingDucksMother)
            {
                FollowDucksMother();
            }
        }

        private void FollowDucksMother()
        {
            Vector3 duckPosition = IsFollowingDucksMother ? FlockManager.Instance.MotherPosition : lastMotherPosition;

            if (IsFollowingDucksMother)
            {
                lastMotherPosition = FlockManager.Instance.MotherPosition;
            }
            
            gameObject.transform.DOMoveX(duckPosition.x + positionShift.x, moveDuration);
            gameObject.transform.DOMoveZ(duckPosition.z + positionShift.z, moveDuration);
        }

        
    }
}

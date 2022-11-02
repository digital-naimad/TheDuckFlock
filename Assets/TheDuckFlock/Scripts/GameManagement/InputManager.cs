using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class InputManager : MonoSingleton<InputManager>   
    {
        [SerializeField] private float inputRefreshUpdate = .5f;
        [SerializeField] private bool isMultitouchEnabled = false;
        [SerializeField, Tooltip("Check if you want to use Swiping instead of Tapping")] private bool isSwipeEnabled = false;

        [SerializeField] private bool _isTouchActive = false;

        public bool IsTouchActive { get { return _isTouchActive; } set { _isTouchActive = value; } }

        private Camera mainCamera;
        private float inputRefreshCounter = 0f;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_isTouchActive)
            {
                inputRefreshCounter += Time.deltaTime;

                if (inputRefreshCounter > inputRefreshUpdate)
                {
                    inputRefreshCounter = 0f;

                    if (Input.touchCount > 0)
                    {
                        //Debug.Log(name + " | TAP ");
                        for (int iTouch = 0; iTouch < (isMultitouchEnabled ? Input.touchCount : 1); iTouch++)
                        {
                            //Debug.Log(name + " | iTouch " + iTouch);
                            Touch singleTouch = Input.touches[iTouch];

                            if (isSwipeEnabled || singleTouch.phase == TouchPhase.Ended) // is finger up?
                            {
                                Vector3 inputPosition = singleTouch.position;
                                inputPosition.z = mainCamera.nearClipPlane;
                                //Debug.Log(name + " | inputPosition x " + inputPosition.x + " y " + inputPosition.y);

                                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(inputPosition);
                                //Debug.Log(name + " | touchPosition x " + touchPosition.x + " y " + touchPosition.y + " z " + touchPosition.z);

                                Debug.DrawRay(touchPosition, Vector3.up, Color.red);

                                WorldManager.Instance.OnTap(touchPosition, mainCamera.orthographic);
                            }
                        }
                    }
                }
            }
        }
    }
}

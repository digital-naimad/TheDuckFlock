using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float inputRefreshUpdate = 0;//.5f;
         private float inputRefreshCounter = 0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            inputRefreshCounter += Time.deltaTime;

            if (inputRefreshCounter > inputRefreshUpdate)
            {
                inputRefreshCounter = 0f;

                // Tapping

                //for (int iTouch = 0; iTouch < Input.touchCount; iTouch++)
                int iTouch = 0;
                if (Input.touchCount > 0)
                {
                    //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[iTouch].position.x, Input.touches[iTouch].position.y, 150));
                    //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[iTouch].position);

                    //if (Input.touches[iTouch].phase == TouchPhase.Ended) // finger is up?
                    {
                        Vector3 inputPosition = Input.touches[iTouch].position;
                        //Debug.Log(name + " >> inputPosition x " + inputPosition.x + " y " + inputPosition.y);

                        inputPosition.z = mainCamera.nearClipPlane;
                        Vector3 touchPosition = mainCamera.ScreenToWorldPoint(inputPosition);
                        //Debug.Log(name + " >> touchPosition x " + touchPosition.x + " y " + touchPosition.y + " z " + touchPosition.z);

                        Debug.DrawRay(touchPosition, Vector3.up, Color.red);


                        WorldManager.Instance.OnTap(touchPosition);
                    }
                }
            }
        }
    }
}

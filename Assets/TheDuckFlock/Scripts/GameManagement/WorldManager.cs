using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class WorldManager : MonoSingleton<WorldManager>
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Transform worldRoot;

        [SerializeField] private Transform dropZoneMarker;
       // [SerializeField] private Transform screenAnchor;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="touchPosition"></param>
        public void OnTap(Vector3 touchPosition)
        {
            Debug.DrawRay(touchPosition, Vector3.up, Color.green);
            Debug.DrawRay(touchPosition, Vector3.down, Color.green);
            Debug.DrawRay(touchPosition, Vector3.left, Color.red);
            Debug.DrawRay(touchPosition, Vector3.right, Color.red);
            Debug.DrawRay(touchPosition, Vector3.forward, Color.blue);
            Debug.DrawRay(touchPosition, Vector3.back, Color.blue);

            
            RaycastWorld(touchPosition);
        }

        private void ThrowGrain(Vector3 position)
        {


            Vector3 fixedPosition = new Vector3(position.x, position.y, 0);
            //new Vector3(position.x + screenAnchor.position.x, 10, position.y + screenAnchor.position.y);
            // new Vector3(position.x, position.y, position.z);
            //new Vector3(position.x, 0, position.y);

            GameObject grainObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Grain);
            grainObject.transform.parent = worldRoot;
            grainObject.transform.position = fixedPosition;

            Debug.Log(name + " >> x " + fixedPosition.x + " y " + fixedPosition.y + " z " + fixedPosition.z);
        }

        private void RaycastWorld(Vector3 positionToCheck)
        {
            RaycastHit hit;

            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 rayDirection = Vector3.Normalize( positionToCheck - cameraPosition);

            if (Physics.Raycast(positionToCheck, rayDirection, out hit, Mathf.Infinity))
            {
                //Debug.DrawRay(positionToCheck, mainCamera.transform.forward * hit.distance, Color.red);
                Debug.DrawRay(positionToCheck, rayDirection, Color.red);

                Debug.Log(">>> Did Hit");


                UpdateDropZoneMarker(hit.point, true);
            }
            else
            {
                //UpdateDropZoneMarker(mainCamera.transform.forward * 1000, false);
                //Debug.DrawRay(positionToCheck, mainCamera.transform.forward * 1000, Color.white);
                Debug.Log(">>> Did not Hit");
            }
        }

        private void UpdateDropZoneMarker(Vector3 position, bool isHit)
        {
            dropZoneMarker.transform.position = position;
            //dropZoneMarker.GetComponent<Renderer>().material.color = isHit ? Color.yellow : Color.red;
        }

        private void DropGrain(Vector3 position)
        {
            GameObject grainObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Grain);
            grainObject.transform.parent = worldRoot;
            grainObject.transform.position = position;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class WorldManager : MonoSingleton<WorldManager>
    {
        [SerializeField] private LayerMask grainLayerMask;

        [SerializeField] private Camera mainCamera;

        [SerializeField] private Transform worldRoot;
        [SerializeField] private Transform terrainRoot;
        [SerializeField] private Transform grainRoot;
        [SerializeField] private Transform flockRoot;

        [SerializeField] private Transform dropZoneMarker;

        /// <summary>
        /// 
        /// </summary>
        public Transform WorldRoot { get { return worldRoot; } }
        public Transform TerrainRoot { get { return terrainRoot; } }
        public Transform GrainRoot { get { return grainRoot; } }
        public Transform FlockRoot { get { return flockRoot; } }


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

        private void RaycastWorld(Vector3 positionToCheck)
        {
            RaycastHit hit;

            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 rayDirection = Vector3.Normalize( positionToCheck - cameraPosition);

            if (Physics.Raycast(positionToCheck, rayDirection, out hit, Mathf.Infinity, grainLayerMask))
            {

                Debug.Log(name + " >> RaycastWorld hit >> " + hit.collider.name);

                //Debug.DrawRay(positionToCheck, rayDirection, Color.red);

                UpdateDropZoneMarker(hit.point, true);

                GrainManager.Instance.SpawnGrainAtPosition(hit.point);
            }
            else
            {
                Debug.Log(name + " >> RaycastWorld not hit anything");
            }
        }

        private void UpdateDropZoneMarker(Vector3 position, bool isHit)
        {
            dropZoneMarker.transform.position = position;
            //dropZoneMarker.GetComponent<Renderer>().material.color = isHit ? Color.yellow : Color.red;
        }

        
    }
}
using UnityEngine;

namespace TheDuckFlock
{
    public class WorldManager : MonoSingleton<WorldManager>
    {
        [SerializeField] private float lostDuckThreshold = -10f;
        [SerializeField] private float lostEggThreshold = -10f;

        [SerializeField] private float hatchEggDistance = 10f;

        [SerializeField] private LayerMask grainLayerMask;

        [SerializeField] private Camera mainCamera;

        [SerializeField] private Transform worldRoot;
        [SerializeField] private Transform terrainRoot;
        [SerializeField] private Transform grainRoot;
        [SerializeField] private Transform flockRoot;
        [SerializeField] private Transform eggsRoot;
        [SerializeField] private Transform nestsRoot;

        [SerializeField] private Transform dropZoneMarker;

        #region Public getters
        public Transform WorldRoot { get { return worldRoot; } }
        public Transform TerrainRoot { get { return terrainRoot; } }
        public Transform GrainRoot { get { return grainRoot; } }
        public Transform FlockRoot { get { return flockRoot; } }
        public Transform EggsRoot { get { return eggsRoot; } }
        public Transform NestsRoot { get { return nestsRoot; } }

        public float LostDuckThreshold { get { return lostDuckThreshold; } }
        public float LostEggThreshold { get { return lostEggThreshold; } }

        public float HatchEggThreshold { get { return hatchEggDistance; } }
        #endregion

        #region GetComponentsInChildren
        public SpawnMarker[] DucksMotherSpawnMarkers { get { return TerrainRoot.GetComponentsInChildren<DucksMotherSpawnMarker>(); } }
        public NestSpawnMarker[] NestSpawnMarkers { get { return TerrainRoot.GetComponentsInChildren<NestSpawnMarker>(); } }
        public SpawnMarker[] EggSpawnMarkers { get { return TerrainRoot.GetComponentsInChildren<EggSpawnMarker>(); } }
        #endregion

        #region Public methods

        /// <summary>
        /// 
        /// </summary>
        /*
        public void HideMarkers()
        {
            var nestMarkers = NestSpawnMarkers;
            var duckMarkers = DucksMotherSpawnMarkers;
            var eggMarkers = EggSpawnMarkers;

        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="touchPosition"></param>
        public void OnTap(Vector3 inputPosition)
        {
            //Debug.Log(name + " | input position: " + inputPosition);

            Vector3 hitPoint = RaycastWorld(inputPosition, grainLayerMask);

            if (hitPoint != Vector3.zero)
            {
                UpdateDropZoneMarker(hitPoint, true);
                GrainManager.Instance.SpawnGrainAtPosition(hitPoint);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionToCheck"></param>
        /// <param name="layerMask"></param>
        /// <returns>RaycastHit position or Vector3.zero if raycast didnt hit anything</returns>
        public Vector3 RaycastWorld(Vector3 inputPosition, LayerMask layerMask)
        {
            Vector3 positionToCheck = mainCamera.ScreenToWorldPoint(inputPosition);

            RaycastHit hit;

            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 rayDirection = mainCamera.orthographic ? mainCamera.transform.forward : Vector3.Normalize( positionToCheck - cameraPosition);

            if (Physics.Raycast(positionToCheck, rayDirection, out hit, Mathf.Infinity, layerMask))
            {
                //Debug.Log(name + "| RaycastWorld hit >> " + hit.collider.name);
                //Debug.DrawRay(positionToCheck, rayDirection, Color.red);

                return hit.point;
            }

            //Debug.Log(name + "| RaycastWorld doesnt hit anything");
            return Vector3.zero;
        }

        private void UpdateDropZoneMarker(Vector3 position, bool isHit)
        {
            dropZoneMarker.transform.position = position;
            //dropZoneMarker.GetComponent<Renderer>().material.color = isHit ? Color.yellow : Color.red;
        }
        #endregion

    }
}
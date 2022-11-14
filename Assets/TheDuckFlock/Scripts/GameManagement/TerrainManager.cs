using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class TerrainManager : MonoSingleton<TerrainManager>
    {
        [SerializeField] private Vector2 gridShift = new Vector2(-24, -104);
        [SerializeField] private Vector2 gridSize = new Vector2(5, 15);
        //[SerializeField] private Vector2 cellSize = new Vector2(18, 18);
        [SerializeField] private Vector2 cellSize = new Vector2(18 * 4, 18 * 4);

        [SerializeField] private GameObject fogPlane;
        [SerializeField] private Vector3 fogScale = new Vector3(.5f, 9f, .5f);
        [SerializeField] private float fogAltitude = -3f;

        #region Getters
        public GameObject CentralSegment { get { return _centralSegment; } }

        private PoolTag RandomTerrainTag 
        { 
            get 
            {
                return poolTags[Random.Range(0, poolTags.Length)];
            } 
        }

        private float RandomTileAngle { get { return tileAngles[Random.Range(0, tileAngles.Length)]; } }

        #endregion

        #region Private fields
        
        private PoolTag[] poolTags = {
            PoolTag.Segment_0,
            PoolTag.Segment_1,
            PoolTag.Segment_2,
            PoolTag.Segment_3,
            PoolTag.Segment_4,
            PoolTag.Segment_5,
            PoolTag.Segment_6,
            PoolTag.Segment_7,
            PoolTag.Segment_8,
            PoolTag.Segment_9
        };

        private float[] tileAngles = { 0, 90, 180, 270 };

        private GameObject _centralSegment;

        #endregion

        private void Awake()
        {
           
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            // TODO: update fog plane position
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        public void GenerateTerrain()
        {
            ClearTerrain();
            SetupFogPlane();

            Debug.Log(name + " >> Generate terrain (x = " + gridSize.x + ", y = " + gridSize.y + ")");

            for (int iRow = 0; iRow < gridSize.y; iRow++)
            {
                for (int iColumn = 0; iColumn < gridSize.x; iColumn++)
                {
                    GameObject newSegment = ObjectPooler.Instance.SpawnFromPool(RandomTerrainTag);
                    newSegment.transform.SetParent(WorldManager.Instance.TerrainRoot, false);
                    newSegment.transform.position = new Vector3(
                        iColumn * cellSize.x + gridShift.x, 
                        0, 
                        iRow * cellSize.y + gridShift.y
                    );

                    newSegment.transform.Rotate(0f, RandomTileAngle, 0.0f, Space.Self);

                    if (iRow == Mathf.Floor(gridSize.y/2) && iColumn == Mathf.Floor(gridSize.x/2))
                    {
                        _centralSegment = newSegment;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearTerrain()
        {
            foreach (Transform child in WorldManager.Instance.TerrainRoot)
            {
                child.gameObject.SetActive(false);
            }
        }

        private void SetupFogPlane()
        {
            fogPlane.SetActive(true);
            fogPlane.transform.localScale = new Vector3(
                gridSize.x * cellSize.x * fogScale.x, 
                fogScale.y, 
                gridSize.y * cellSize.y * fogScale.z);

            //fogPlane.transform.position = new Vector3(gridShift.x, fogAltitude, gridShift.y);
        }

    }
}

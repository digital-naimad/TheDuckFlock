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

        private PoolTag RandomTerrainTag 
        { 
            get 
            {
                return poolTags[Random.Range(0, poolTags.Length)];
            } 
        }

        private float RandomTileAngle { get { return tileAngles[Random.Range(0, tileAngles.Length)]; } }

        // private PoolTag[] poolTags = { PoolTag.GrassTerrain, PoolTag.EmptyTerrain, PoolTag.GrassWithFences };
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

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        public void GenerateTerrain()
        {
            ClearTerrain();

            Debug.Log(name + " >> Generate terrain x=" + gridSize.x + " y=" + gridSize.y);

            for (int iRow = 0; iRow < gridSize.y; iRow++)
            {
                for (int iColumn = 0; iColumn < gridSize.x; iColumn++)
                {
                    GameObject newTile = ObjectPooler.Instance.SpawnFromPool(RandomTerrainTag);
                    newTile.transform.SetParent(WorldManager.Instance.TerrainRoot, false);
                    newTile.transform.position = new Vector3(
                        iColumn * cellSize.x + gridShift.x, 
                        0, 
                        iRow * cellSize.y + gridShift.y
                    );

                    newTile.transform.Rotate(0f, RandomTileAngle, 0.0f, Space.Self);
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
    }
}

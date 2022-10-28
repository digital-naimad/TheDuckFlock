using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class TerrainManager : MonoSingleton<TerrainManager>
    {

        //[SerializeField] private List<GameObject> terrainprefabs = new List<TerrainType>();
        //[SerializeField] private List<TerrainType> terrainTypes = new List<TerrainType>();
        [SerializeField] private Vector2 gridShift = new Vector2(-24, -104);
        [SerializeField] private Vector2 gridSize = new Vector2(5, 15);
        [SerializeField] private Vector2 cellSize = new Vector2(16, 16);

        [SerializeField] private Transform terrainRoot;

        private PoolTag RandomTerrainTag 
        { 
            get 
            {
                return poolTags[Random.Range(0, poolTags.Length)];
            } 
        }

        private float RandomTileAngle { get { return tileAngles[Random.Range(0, tileAngles.Length)]; } }

        private PoolTag[] poolTags = { PoolTag.GrassTerrain, PoolTag.EmptyTerrain, PoolTag.GrassWithFences };

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
            Debug.Log(name + " >> Generate terrain x=" + gridSize.x + " y=" + gridSize.y);

            for (int iRow = 0; iRow < gridSize.y; iRow++)
            {
                for (int iColumn = 0; iColumn < gridSize.x; iColumn++)
                {
                    GameObject newTile = ObjectPooler.Instance.SpawnFromPool(RandomTerrainTag);
                    newTile.transform.SetParent(terrainRoot, false);
                    newTile.transform.position = new Vector3(
                        iColumn * cellSize.x + gridShift.x, 
                        0, 
                        iRow * cellSize.y + gridShift.y
                    );

                    newTile.transform.Rotate(0f, RandomTileAngle, 0.0f, Space.Self);
                }
            }
        }
    }
}

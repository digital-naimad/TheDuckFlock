using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class TerrainManager : MonoSingleton<TerrainManager>
    {

        //[SerializeField] private List<GameObject> terrainprefabs = new List<TerrainType>();
        //[SerializeField] private List<TerrainType> terrainTypes = new List<TerrainType>();

        [SerializeField] private Vector2 gridSize = new Vector2(5, 10);
        [SerializeField] private Vector2 cellSize = new Vector2(8, 8);

        [SerializeField] private Transform terrainRoot;

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


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class TerrainManager : MonoBehaviour
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
    }
}

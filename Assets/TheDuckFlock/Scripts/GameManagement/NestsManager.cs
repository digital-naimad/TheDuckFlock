using UnityEngine;

namespace TheDuckFlock
{
    public class NestsManager : MonoSingleton<NestsManager>
    {



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        ///  /// <summary>
        /// Spawns Nest prefab at the position of randomely choosen NestSpawnMarker
        /// 
        /// </summary>
        /// <returns>Centrally placed NestSpawnMarker</returns>
        public NestSpawnMarker SpawnNest()
        {
            Debug.Log(name + " | SpawnNest");

            NestSpawnMarker choosenMarker = TerrainManager.Instance.CentralSegment.GetComponentInChildren<NestSpawnMarker>(); 

            GameObject nestObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Nest);
            nestObject.transform.parent = WorldManager.Instance.NestsRoot;
            nestObject.transform.position = choosenMarker.transform.position;

            return choosenMarker;
        }
    }
}

using UnityEngine;

namespace TheDuckFlock
{
    public class NestsManager : MonoSingleton<NestsManager>
    {
        public float NestScopeRadius { get { return 4; } }
        public Vector3 NestPosition
        {
            get
            {
                return nestTransform.position;
            }
        }

        private Transform nestTransform;

        /// <summary>
        ///  /// <summary>
        /// Spawns Nest prefab at the position of randomely choosen NestSpawnMarker
        /// 
        /// </summary>
        /// <returns>Centrally placed NestSpawnMarker</returns>
        public NestSpawnMarker SpawnNest()
        {
            // Debug.Log(name + " | SpawnNest");

            NestSpawnMarker choosenMarker = TerrainManager.Instance.CentralSegment.GetComponentInChildren<NestSpawnMarker>(); 

            GameObject nestObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Nest);
            nestObject.transform.parent = WorldManager.Instance.NestsRoot;
            nestObject.transform.position = choosenMarker.transform.position;

            nestTransform = nestObject.transform;

            return choosenMarker;
        }


    }
}

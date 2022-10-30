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
        /// Spawns Nest prefab at the position of randomely choosen NestSpawnMarker
        /// </summary>
        public NestSpawnMarker SpawnNest()
        {
            Debug.Log(name + " | SpawnNest");

            NestSpawnMarker[] nestSpawnMarkers = WorldManager.Instance.NestSpawnMarkers;
            NestSpawnMarker choosenMarker = nestSpawnMarkers[Random.Range(0, nestSpawnMarkers.Length)];
            //choosenMarker.transform.localScale = Vector3.one * 5;

            GameObject nestObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Nest);
            nestObject.transform.parent = WorldManager.Instance.NestsRoot;
            nestObject.transform.position = choosenMarker.transform.position;

            return choosenMarker;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class EggsManager : MonoSingleton<EggsManager>
    {

        private SpawnMarker[] EggSpawnMarkers
        {
            get
            {
                if (_eggSpawnMarkers == null)
                {
                    _eggSpawnMarkers = WorldManager.Instance.TerrainRoot.GetComponentsInChildren<EggSpawnMarker>();
                }

                return _eggSpawnMarkers;
            }
        }
        private SpawnMarker[] _eggSpawnMarkers = null;

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
        /// <param name="spawnMarker"> optional - if left blank, then will be randomized</param>
        public void SpawnEgg(EggSpawnMarker eggSpawnMarker = null)
        {
            Debug.Log(name + " | Spawn Egg ");

            // Sets object active
            GameObject eggObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Egg);
            eggObject.SetActive(true);

            // Hides marker
            SpawnMarker spawnMarker = eggSpawnMarker == null ? EggSpawnMarkers[Random.Range(0, EggSpawnMarkers.Length)] : eggSpawnMarker;
            spawnMarker.Hide();
            spawnMarker.IsUsed = true;

            // Sets position
            eggObject.transform.parent = WorldManager.Instance.EggsRoot;
            eggObject.transform.position = spawnMarker.transform.position;

            
        }
    }
}

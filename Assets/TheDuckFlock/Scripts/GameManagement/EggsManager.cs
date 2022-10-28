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
        public void SpawnEgg()
        {
            Debug.Log(name + " >> Spawn Egg >> markers count=" + EggSpawnMarkers.Length);

            // Sets object active
            GameObject eggObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Egg);
            eggObject.SetActive(true);

            // Hides marker
            SpawnMarker spawnMarker = EggSpawnMarkers[Random.Range(0, EggSpawnMarkers.Length)];
            spawnMarker.Hide();
            spawnMarker.IsUsed = true;

            // Sets position
            eggObject.transform.parent = WorldManager.Instance.EggsRoot;
            eggObject.transform.position = spawnMarker.transform.position;

            
        }
    }
}

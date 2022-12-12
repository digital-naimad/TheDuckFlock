using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class EggsManager : MonoSingleton<EggsManager>
    {
        /*
        private EggSpawnMarker[] EggSpawnMarkers
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
        */
        private EggSpawnMarker RandomEggSpawnMarker
        {
            get
            {
                //if (_spawnMarkers.Count == 0)
                {
                    CacheEggSpawnMarkers();
                }

                foreach (EggSpawnMarker marker in _spawnMarkers)
                {
                    if (Vector3.Distance(FlockManager.Instance.MotherPosition, marker.transform.position) > 18*2)
                    {
                        return marker;
                    }
                }

                return null; // just in case

            }
        }

        //private SpawnMarker[] _eggSpawnMarkers = null;
        private List<EggSpawnMarker> _spawnMarkers = new List<EggSpawnMarker>();

        public void CacheEggSpawnMarkers()
        {
            EggSpawnMarker[] markersArray = WorldManager.Instance.TerrainRoot.GetComponentsInChildren<EggSpawnMarker>();
            foreach (EggSpawnMarker marker in markersArray)
            {
                _spawnMarkers.Add(marker);

            }

            _spawnMarkers.Shuffle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spawnMarker"> optional - if left blank, then will be randomized</param>
        public void SpawnEgg(EggSpawnMarker eggSpawnMarker = null)
        {
           // // // // // Debug.Log(name + " | Spawn Egg ");

            // Sets object active
            GameObject eggObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Egg);
            eggObject.SetActive(true);

            // Hides marker
            SpawnMarker spawnMarker = eggSpawnMarker == null ? RandomEggSpawnMarker : eggSpawnMarker;
            spawnMarker.Hide();
            spawnMarker.IsUsed = true;

            // Sets position
            eggObject.transform.parent = WorldManager.Instance.EggsRoot;
            eggObject.transform.position = spawnMarker.transform.position;

            

            
        }
    }
}

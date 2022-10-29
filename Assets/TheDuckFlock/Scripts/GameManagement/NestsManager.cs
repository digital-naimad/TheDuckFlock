using System.Collections;
using System.Collections.Generic;
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

        public void SpawnNest()
        {
            NestSpawnMarker[] nestSpawnMarkers = WorldManager.Instance.NestSpawnMarkers;
            NestSpawnMarker choosenMarker = nestSpawnMarkers[Random.Range(0, nestSpawnMarkers.Length)];
            choosenMarker.Hide();

        }
    }
}

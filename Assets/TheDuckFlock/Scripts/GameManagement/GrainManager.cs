using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TheDuckFlock
{
    public class GrainManager : MonoSingleton<GrainManager>
    {
        [SerializeField] private List<GameObject> grainList = new List<GameObject>();

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
        /// <param name="positionToSpawn"></param>
        public void SpawnGrainAtPosition(Vector3 positionToSpawn)
        {

            GameObject grainObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Grain);
            grainObject.transform.parent = WorldManager.Instance.WorldRoot;
            grainObject.transform.position = positionToSpawn;
            grainObject.GetComponent<GrainController>().RestartParticles();

            grainList.Add(grainObject);
        }
    }
}

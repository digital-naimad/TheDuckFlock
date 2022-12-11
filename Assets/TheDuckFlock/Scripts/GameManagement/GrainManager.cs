using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class GrainManager : MonoSingleton<GrainManager>
    {
        //[SerializeField] private List<GrainController> grainList = new List<GrainController>();

        private GrainController[] GrainTable
        {
            get
            {
                return WorldManager.Instance.GrainRoot.GetComponentsInChildren<GrainController>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionToSpawn"></param>
        public void SpawnGrainAtPosition(Vector3 positionToSpawn)
        {
            //Debug.Log(name + " | Spawn grain at position = " + positionToSpawn);

            GameObject grainObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Grain);
            grainObject.transform.parent = WorldManager.Instance.GrainRoot;
            grainObject.transform.position = positionToSpawn;

            GrainController grainController = grainObject.GetComponent<GrainController>();
            grainController.RestartParticles();
            

           // grainList.Add(grainController);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionToCheck"></param>
        /// <returns>can be null if there is no any GrainController spawned</returns>
        public GrainController GetClosestGrain(Vector3 positionToCheck)
        {
            GrainController[] grainTable = WorldManager.Instance.GrainRoot.GetComponentsInChildren<GrainController>();

            //Debug.Log(name + " | grain piles count = " + grainTable.Length);   
            //GrainController[] grainTable = GrainTable;

            if (grainTable.Length == 0)
            //if (grainList.Count == 0)
            {
                return null;
            }

            float minDistance = float.PositiveInfinity;
            GrainController closestGrainController = null;

            foreach (GrainController grain in grainTable)
            //foreach (GrainController grain in grainList)
            {
                float distance = Vector3.Distance(positionToCheck, grain.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestGrainController = grain;
                }
                
            }

            return closestGrainController;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grainToPeck"></param>
        public void Peck(GrainController grainToPeck)
        {
            grainToPeck.gameObject.SetActive(false);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearAllGrain()
        {
            //foreach (GrainController grain in grainList)
            foreach (GrainController grain in GrainTable)
            {
                grain.gameObject.SetActive(false);

            }
           // grainList.Clear();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class FlockManager : MonoSingleton<FlockManager>
    {

        [SerializeField] private List<DucksMother> duckMothers = new List<DucksMother>();
        [SerializeField] private List<Duckie> duckies = new List<Duckie>();

        /// <summary>
        /// 
        /// </summary>
        //public DucksMother Mother { get { return duckMothers[0]; } }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 MotherPosition { get { return duckMothers[0].transform.position; } }

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
        public void SpawnDucksMother()
        {
            // Sets DucksMother active
            GameObject duckObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.DucksMother);
            duckObject.SetActive(true);

            // Adds mother to list
            DucksMother newDuck = duckObject.GetComponent<DucksMother>();
            duckMothers.Add(newDuck);

            // Hide spawn marker
            SpawnMarker marker = WorldManager.Instance.FlockRoot.GetComponentInChildren<SpawnMarker>();
            marker.Hide();
             
            // Sets position
            duckObject.transform.position = marker.transform.position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionToCheck"></param>
        /// <returns></returns>
        public DuckController GetClosestDuckController(Vector3 positionToCheck)
        {

            DuckController[] ducksTable = WorldManager.Instance.FlockRoot.GetComponentsInChildren<DuckController>();

            Debug.Log(name + " >> ducks count = " + ducksTable.Length);

            if (ducksTable.Length == 0)
            {
                return null;
            }

            float minDistance = float.PositiveInfinity;
            DuckController closestDuckController = null;

            foreach (DuckController duck in ducksTable)
            {
                float distance = Vector3.Distance(positionToCheck, duck.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestDuckController = duck;
                }

            }

            return closestDuckController;

        }
    }
}

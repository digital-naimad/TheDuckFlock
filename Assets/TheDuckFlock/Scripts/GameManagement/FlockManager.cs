using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class FlockManager : MonoSingleton<FlockManager>
    {

        [SerializeField] private List<DucksMother> duckMothers = new List<DucksMother>();
        [SerializeField] private List<Duckie> duckies = new List<Duckie>();

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

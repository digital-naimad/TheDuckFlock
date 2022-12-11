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
        public Vector3 MotherPosition { get { return duckMothers.Count == 0 ? Vector3.one * 1000 : duckMothers[0].transform.position; } }

        public int CurrentDuckiesCount
        {
            get { return duckies.Count; }
        }

        public int LostDuckiesCount
        { 
            get { return _lostDuckiesCount; } 
        }

        //private int _currentDuckiesCount = 0;

        private int _lostDuckiesCount = 0;


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
        public void SpawnDucksMother(DucksMotherSpawnMarker marker)
        {
            // Sets DucksMother active
            GameObject duckObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.DucksMother);

            // Sets position
            duckObject.transform.parent = WorldManager.Instance.FlockRoot;
            duckObject.transform.position = marker.transform.position + Vector3.up;

            // Adds mother to list
            DucksMother newDuck = duckObject.GetComponent<DucksMother>();
            duckMothers.Add(newDuck);

            duckObject.SetActive(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eggPosition"></param>
        public void SpawnDuckie(Vector3 eggPosition)
        {
            // Sets Duckie active
            GameObject duckObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.Duckie);
            duckObject.SetActive(true);

            // Sets position
            duckObject.transform.parent = WorldManager.Instance.FlockRoot;
            duckObject.transform.position = eggPosition;

            // Adds Duckie to list
            Duckie newDuck = duckObject.GetComponent<Duckie>();
            duckies.Add(newDuck);

           // _currentDuckiesCount++;
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveAllDucks()
        {
            // Clears lists
            duckMothers.Clear();
            duckies.Clear();

            // Clears FlockRoot
            DuckController[] ducks = WorldManager.Instance.FlockRoot.GetComponentsInChildren<DuckController>();

            foreach (DuckController duck in ducks)
            {
                duck.transform.SetParent(ObjectPooler.Instance.PoolRoot, false);
                duck.transform.position = Vector3.zero;
                duck.gameObject.SetActive(false);
            }

            //_currentDuckiesCount = 0;
            _lostDuckiesCount = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionToCheck"></param>
        /// <returns></returns>
        public DuckController GetClosestDuckController(Vector3 positionToCheck, DuckController duckToExclude = null)
        {

            DuckController[] ducks = WorldManager.Instance.FlockRoot.GetComponentsInChildren<DuckController>();

            //Debug.Log(name + " >> ducks count = " + ducks.Length);

            if (ducks.Length == 0)
            {
                return null;
            }

            float minDistance = float.PositiveInfinity;
            DuckController closestDuckController = null;

            foreach (DuckController duck in ducks)
            {
                if (duckToExclude == null || duckToExclude != duck)
                {
                    float distance = Vector3.Distance(positionToCheck, duck.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestDuckController = duck;
                    }
                }

            }

            return closestDuckController;

        }

        /// <summary>
        /// 
        /// </summary>
        public void IncrementLostDuckiesCounter()
        {
            _lostDuckiesCount++;

            Debug.Log(name + " | current lost duckies count: " + _lostDuckiesCount);


        }
      
    }
}

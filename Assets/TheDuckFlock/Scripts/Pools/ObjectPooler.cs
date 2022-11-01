using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    /// <summary>
    /// Universal object pooler. Implements Pool Pattern. Calls OnSpawn method of IPooledObject interface. Listens for Pause event to disable all pooled objects
    /// </summary>
    public class ObjectPooler : MonoSingleton<ObjectPooler>
    {
        #region Inspector fields
        [SerializeField] private List<Pool> poolsList;

        [SerializeField] private Transform poolRoot;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Transform PoolRoot { get { return poolRoot; } }

        private Dictionary<PoolTag, Queue<GameObject>> poolDictionary;

        #region Life-cycle callbacks
        private void Awake()
        {
            //GameplayEventsManager.Instance.RegisterListener(GameplayEventType.PauseSpawning, (foo) => { OnPause(); });

            poolDictionary = new Dictionary<PoolTag, Queue<GameObject>>();

            foreach (Pool pool in poolsList)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.poolSize; i++)
                {
                    GameObject newObject = Instantiate(pool.prefab);
                    newObject.SetActive(false);
                    objectPool.Enqueue(newObject);
                    newObject.transform.SetParent(poolRoot, false);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        private void OnDestroy()
        {
            //GameplayEventsManager.Instance.UnregisterListener(GameplayEventType.PauseSpawning, (foo) => { OnPause(); });
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag">string</param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public GameObject SpawnFromPool(PoolTag tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.Log(name + " | Warning: Pool with tag " + tag + " does not exist");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

            if (pooledObject != null)
            {
                pooledObject.OnSpawn();
            }

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

        public GameObject SpawnFromPool(PoolTag tag)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.Log(name + " | Warning: Pool with tag " + tag + " does not exist");
                return null;
            }

            //Debug.Log(name + " SPAWN FROM  POOL >> current count " + poolDictionary[tag].Count);
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(false);
            objectToSpawn.SetActive(true);


            IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

            if (pooledObject != null)
            {
                pooledObject.OnSpawn();
            }
            

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

        /// <summary>
        /// Deactivates all pooled objects by iterating dictionary and then queue of a GameObjects
        /// </summary>
        private void OnPause()
        {
            foreach (Pool pool in poolsList)
            {
                Queue<GameObject>.Enumerator enumerator = poolDictionary[pool.tag].GetEnumerator();
                while (enumerator.MoveNext())
                {
                    enumerator.Current.SetActive(false);
                }
            }
        }

    }
}
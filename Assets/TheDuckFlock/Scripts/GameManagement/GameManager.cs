using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuckFlock
{
    public class GameManager : MonoSingleton<GameManager>
    {
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
        public void StartGame()
        {
            Debug.Log(name + " >> Starts game");

            //TerrainManager.Instance.GenerateTerrain();
            GameplayManager.Instance.LaunchNextStage();
           

        }
    }
}

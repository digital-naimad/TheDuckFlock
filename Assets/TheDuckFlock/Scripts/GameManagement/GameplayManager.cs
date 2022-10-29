
using UnityEngine;

namespace TheDuckFlock
{
    public class GameplayManager : MonoSingleton<GameplayManager>
    {

        private void Awake()
        {
            CameraController.Instance.IsFollowDucksMother = false;
        }


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
        public void LaunchNextStage()
        {
            Debug.Log(name + " | LaunchNextStage");

            DucksMotherSpawnMarker motherMarker = NestsManager.Instance.SpawnNest();
            FlockManager.Instance.SpawnDucksMother(motherMarker);
            CameraController.Instance.IsFollowDucksMother = true; // warning: order of the calls matters
        }
       

        

    }
}


using UnityEngine;

namespace TheDuckFlock
{
    public class GameplayManager : MonoSingleton<GameplayManager>, IGameplayEventsListener
    {

        private void Awake()
        {
            CameraController.Instance.IsFollowDucksMother = false;

            GameplayEventsManager.SetupListeners(this);
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

            NestSpawnMarker nestMarker = NestsManager.Instance.SpawnNest();
            DucksMotherSpawnMarker motherMarker = nestMarker.DucksMotherSpawnMarker;
            FlockManager.Instance.SpawnDucksMother(motherMarker);
            CameraController.Instance.IsFollowDucksMother = true; // warning: order of the calls matters
        }


        public void OnStartGame(params int[] parameters)
        {
            LaunchNextStage();

            

        }

        private void OnDestroy()
        {
            GameplayEventsManager.RemoveListeners();
        }

    }
}

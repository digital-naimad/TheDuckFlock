
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




        public void OnStartGame(params int[] parameters)
        {
            Debug.Log(name + " | OnStartGame()");

            TerrainManager.Instance.GenerateTerrain();

            NestSpawnMarker nestMarker = NestsManager.Instance.SpawnNest();

            EggsManager.Instance.SpawnEgg(nestMarker.EggSpawnMarker);
            FlockManager.Instance.SpawnDucksMother(nestMarker.DucksMotherSpawnMarker);

            CameraController.Instance.IsFollowDucksMother = true; // warning: order of the calls matters

        }

        public void OnDucksMotherLost()
        {
            CameraController.Instance.IsFollowDucksMother = false;
            //
        }

        private void OnDestroy()
        {
            GameplayEventsManager.RemoveListeners();
        }

    }
}

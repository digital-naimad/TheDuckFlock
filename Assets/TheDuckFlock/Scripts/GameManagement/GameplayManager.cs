
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

        #region MonoBehaviour callbacks
        // Start is called before the first frame update
        /*
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
        */

        private void OnDestroy()
        {
            GameplayEventsManager.RemoveListeners();
        }
        #endregion

        #region GameplayEvent listeners
        public void OnStartGame(params int[] parameters)
        {
            Debug.Log(name + " | OnStartGame()");

            TerrainManager.Instance.GenerateTerrain();

            NestSpawnMarker nestMarker = NestsManager.Instance.SpawnNest();

            EggsManager.Instance.SpawnEgg(nestMarker.EggSpawnMarker);
            FlockManager.Instance.SpawnDucksMother(nestMarker.DucksMotherSpawnMarker);

            CameraController.Instance.IsFollowDucksMother = true; // warning: order of the calls matters

        }

        public void OnDucksMotherLost(params int[] parameters)
        {
            CameraController.Instance.IsFollowDucksMother = false;
        }

        /// <summary>
        /// Spawns random new egg
        /// </summary>
        /// <param name="parameters"></param>
        public void OnEggLost(params int[] parameters)
        {
            EggsManager.Instance.SpawnEgg();
        }

        public void OnEggHatched(params int[] parameters)
        {
            /// TODO:
            /// * clear hatched egg (with animation?)
            /// * spawn new duckie

            EggsManager.Instance.SpawnEgg();
        }
        #endregion
    }
}

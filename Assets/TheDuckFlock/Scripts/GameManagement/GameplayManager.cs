using UnityEngine;

namespace TheDuckFlock
{
    public class GameplayManager : MonoSingleton<GameplayManager>, IGameplayEventsListener<Vector3>
    {

        private void Awake()
        {
            CameraController.Instance.IsFollowingDucksMother = false;
            

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
        public void OnStartGame(params Vector3[] parameters)
        {
            Debug.Log(name + " | OnStartGame()");

            TerrainManager.Instance.GenerateTerrain();

            NestSpawnMarker nestMarker = NestsManager.Instance.SpawnNest();

            EggsManager.Instance.SpawnEgg(nestMarker.EggSpawnMarker);
            FlockManager.Instance.SpawnDucksMother(nestMarker.DucksMotherSpawnMarker);

            CameraController.Instance.IsFollowingDucksMother = true; // warning: order of the calls matters
        }

        public void OnDucksMotherLost(params Vector3[] parameters)
        {
            CameraController.Instance.IsFollowingDucksMother = false;
           
            FlockManager.Instance.RemoveAllDucks();
            UIManager.Instance.ShowResultScreen();
        }

        public void OnDuckieLost(params Vector3[] parameters)
        {
            Debug.Log(name + " | OnDuckieLost");
            
        }

        /// <summary>
        /// Spawns random new egg
        /// </summary>
        /// <param name="parameters"></param>
        public void OnEggLost(params Vector3[] parameters)
        {
            EggsManager.Instance.SpawnEgg();
            EggsManager.Instance.SpawnEgg();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">Should provide position of the hatched Egg at index 0</param>
        public void OnEggHatched(params Vector3[] parameters)
        {
            FlockManager.Instance.SpawnDuckie(parameters[0]);

            EggsManager.Instance.SpawnEgg();


        }

       
        #endregion
    }
}

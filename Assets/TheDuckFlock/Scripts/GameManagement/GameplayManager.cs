using DG.Tweening;
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

            ScoreManager.Instance.IncreaseScoreGoal();
            UIManager.Instance.SetScoreGoal(ScoreManager.Instance.CurrentScoreGoal);
            UIManager.Instance.SwitchIndicatorsVisibility(true);

            EggsManager.Instance.SpawnEgg(nestMarker.EggSpawnMarker);

            for (int i = 0; i < ScoreManager.Instance.CurrentScoreGoal; i++)
            {
                EggsManager.Instance.SpawnEgg();
            }

            FlockManager.Instance.SpawnDucksMother(nestMarker.DucksMotherSpawnMarker);

            for (int i = 0; i < ScoreManager.Instance.currentFlockSize; i++)
            {
                DOVirtual.DelayedCall(i * .25f, () =>
                {
                    FlockManager.Instance.SpawnDuckie(nestMarker.DucksMotherSpawnMarker.transform.position);
                });
                
            }


            CameraController.Instance.IsFollowingDucksMother = true; // warning: order of the calls matters
            InputManager.Instance.IsTouchActive = true;
        }

        public void OnDucksMotherLost(params Vector3[] parameters)
        {
            CameraController.Instance.IsFollowingDucksMother = false;
           
            FlockManager.Instance.RemoveAllDucks();

            ScoreManager.Instance.AddToLostDuckies(WorldManager.Instance.FlockRoot.childCount);
            UIManager.Instance.ShowResultScreen();

            ScoreManager.Instance.ResetScore();
            UIManager.Instance.SetScoreGoal(1);
        }

        public void OnDuckieLost(params Vector3[] parameters)
        {
            Debug.Log(name + " | OnDuckieLost");

            ScoreManager.Instance.OnDuckieLost();
            UIManager.Instance.UpdateScore(ScoreManager.Instance.CurrentScore);

            FlockManager.Instance.IncrementLostDuckiesCounter();
            
        }

        /// <summary>
        /// Spawns random new egg
        /// </summary>
        /// <param name="parameters"></param>
        public void OnEggLost(params Vector3[] parameters)
        {
            Debug.Log(name + " | OnEggLost");

            EggsManager.Instance.SpawnEgg();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">Should provide position of the hatched Egg at index 0</param>
        public void OnEggHatched(params Vector3[] parameters)
        {
            ScoreManager.Instance.OnDuckieHatched();

            Debug.Log(name + " | OnEggHatched current score " + ScoreManager.Instance.CurrentScore);

            UIManager.Instance.UpdateScore(ScoreManager.Instance.CurrentScore);

            FlockManager.Instance.SpawnDuckie(parameters[0]);

            for (int i = 0; i < ScoreManager.Instance.CurrentScoreGoal * 2; i++)
            {
                EggsManager.Instance.SpawnEgg();
            }
        }

        public void OnReturnedToNest(params Vector3[] parameters)
        {
            InputManager.Instance.IsTouchActive = false;

            UIManager.Instance.ShowResultScreen();

            ScoreManager.Instance.IncrementLevelIfGoalAchieved();

            FlockManager.Instance.RemoveAllDucks();
        }

        public void OnScoreGoalAchieved(params Vector3[] parameters)
        {
            Debug.Log(name + " | OnScoreGoalAchieved ");

            UIManager.Instance.SwitchNestIndicatorVisibility(true);

        }

        public void OnScoreGoalLost(params Vector3[] parameters)
        {
            Debug.Log(name + " | OnScoreGoalLost ");

            UIManager.Instance.SwitchNestIndicatorVisibility(false);
        }

       


        #endregion
    }
}

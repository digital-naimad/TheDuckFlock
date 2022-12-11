using UnityEngine;

namespace TheDuckFlock
{
    public class ScoreManager : MonoSingleton<ScoreManager>
    {
        [SerializeField] private int _currentScoreGoal = 1;
        [SerializeField] private GameObject scoreIndicatorsRoot;

        [SerializeField] private int _currentScore = 0;

        public int CurrentScoreGoal
        {
            get { return _currentScoreGoal; }
            set { _currentScoreGoal = value; }
        }

        /*public bool IsScoreGoalAchieved
        {
            get { return _isScoreGoalAchieved;}
        }*/

        public int CurrentScore { get { return _currentScore; } }

        public int LostDuckies { get { return _lostDuckies; } }

        public int CurrentLevel { get { return _currentLevel; } }

        public bool WasGoalAchieved { get { return CurrentScore >= CurrentScoreGoal; } }

        public int CurrentFlockSize
        {
            get { return _currentFlockSize; }
        }

        public int _currentFlockSize = 0;

        private int _lostDuckies = 0;

        private int _currentLevel = 1;

        //private bool _isScoreGoalAchieved = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isVisible"></param>
        public void SwitchScoreVisibility(bool isVisible)
        {
            scoreIndicatorsRoot.SetActive(isVisible);
        }

        public void IncreaseScoreGoal()
        {
            _currentScoreGoal += 2;
        }

        public void IncrementLevelIfGoalAchieved()
        {
            //if (IsScoreGoalAchieved)
            if (WasGoalAchieved)
            {
                _currentLevel++;
                //_isScoreGoalAchieved = false;
            }
        }

        public void OnDuckieLost()
        {
            Debug.Log(name + " | On Duckie Lost");

            _currentScore = Mathf.Max(_currentScore - 1, 0);
            _lostDuckies++;
            _currentFlockSize = Mathf.Max(_currentFlockSize - 1, 0);

            Debug.Log(name + " | On Duckie Lost score: " + _currentScore);

            if (_currentScore == CurrentScoreGoal - 1)
            {
                GameplayEventsManager.DispatchEvent(GameplayEvent.ScoreGoalLost);
            }
        }

        public void OnDuckieHatched()
        {
            
            _currentScore++;
            _currentFlockSize++;

            Debug.Log(name + " | DuckieHatched, current score " + _currentScore);

            //if (_currentScore >= CurrentScoreGoal)
            if (WasGoalAchieved)
            {
               // _isScoreGoalAchieved = true;
                GameplayEventsManager.DispatchEvent(GameplayEvent.ScoreGoalAchieved);

            }
        }

        public void ResetScore()
        {
            _currentScore = 0;
            _lostDuckies = 0;
            //_currentLevel = 1;
        }

        public void ResetFlockSize()
        {
            _currentFlockSize = 0;
        }
        /*
        public void AddToLostDuckies(int toAdd)
        {
            _lostDuckies += toAdd;
        }
        */

    }
}

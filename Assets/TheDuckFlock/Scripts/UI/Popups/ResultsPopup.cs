using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TheDuckFlock
{
    public class ResultsPopup : PopupBase
    {
        [SerializeField] private TextMeshProUGUI titleLabel;

        [SerializeField] private TextMeshProUGUI hatchedDuckiesValueText;
        [SerializeField] private TextMeshProUGUI lostDuckiesValueText;

        [SerializeField] private Button buttonRestart;
        
        private int hatchedEggs = 0;
        private int lostDuckies = 0;

        // Start is called before the first frame update
        void Start()
        {
           // UpdateValues(3, 4);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetupButton(bool isGoalAchieved)
        {
            buttonPlay.gameObject.SetActive(isGoalAchieved);
            buttonRestart.gameObject.SetActive(!isGoalAchieved);
        }

        public void UpdateValues(int hatched, int lost)
        {
            hatchedEggs = hatched;
            lostDuckies = lost;

            RefreshValues();
        }

        

        public void RefreshValues()
        {
            hatchedDuckiesValueText.text = "" + ScoreManager.Instance.CurrentScore;
            lostDuckiesValueText.text = "" + ScoreManager.Instance.LostDuckies;

            titleLabel.text = "Level " + ScoreManager.Instance.CurrentLevel;
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnPlayButtonClick()
        {
            Debug.Log(name + " | OnPlayButtonClick() >>");

            GameplayEventsManager.DispatchEvent(GameplayEvent.StartGame);
            ScoreManager.Instance.IncreaseScoreGoal();

            HideResultsPopup();
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnRestartButtonClick()
        {
            Debug.Log(name + " | OnRestartButtonClick() >>");

           

            GameplayEventsManager.DispatchEvent(GameplayEvent.RestartGame);

            HideResultsPopup();
        }

        public void HideResultsPopup()
        {
            ScreenFader.Instance.DoFade(true);
            HidePopup(true);
        }
    }
}

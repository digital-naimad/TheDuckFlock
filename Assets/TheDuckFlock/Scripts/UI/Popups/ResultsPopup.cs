using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace TheDuckFlock
{
    public class ResultsPopup : PopupBase
    {
        [SerializeField] private TextMeshProUGUI titleLabel;

        [SerializeField] private TextMeshProUGUI hatchedDuckiesValueText;
        [SerializeField] private TextMeshProUGUI lostDuckiesValueText;

        [SerializeField] private Button buttonRestart;
        [SerializeField] private Button buttonQuit;

        private int hatchedEggs = 0;
        private int lostDuckies = 0;

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
            // Debug.Log(name + " | OnPlayButtonClick() >>");

            GameplayEventsManager.DispatchEvent(GameplayEvent.StartGame);
            

            HideResultsPopup();

            SoundManager.Instance.PlaySound(SoundTag.ButtonClick);
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnRestartButtonClick()
        {
           // Debug.Log(name + " | OnRestartButtonClick() >>");

            GameplayEventsManager.DispatchEvent(GameplayEvent.RestartGame);

            HideResultsPopup();

            SoundManager.Instance.PlaySound(SoundTag.ButtonClick);
        }

        public void OnQuitButtonClick(float eventDispatchingDelayDuration = 1f)
        {
            // Debug.Log(name + " | OnQuitButtonClick() >>");

            HideResultsPopup(false);

            DOVirtual.DelayedCall(eventDispatchingDelayDuration, () =>
            {
                GameplayEventsManager.DispatchEvent(GameplayEvent.QuitGame);
            });

            SoundManager.Instance.PlaySound(SoundTag.ButtonClick);
        }

        public void HideResultsPopup(bool isWithFade = true)
        {
            ScreenFader.Instance.DoFade(isWithFade);
            HidePopup(true);
        }

        public void ShowResultsPopup()
        {
            ShowPopup(true);

            SoundManager.Instance.TurnOffWithFade(SoundTag.MusicGameplay);
            SoundManager.Instance.PlayMusic(SoundTag.MusicMenu);

            buttonPlay.transform.DOScale(1f, showAnimationDuration)
                .SetDelay(showAnimationDuration / 3)
                .From(0f, true)
                .SetEase(Ease.OutBack);

            buttonRestart.transform.DOScale(1f, showAnimationDuration)
                .SetDelay(showAnimationDuration / 3 )
                .From(0f, true)
                .SetEase(Ease.OutBack);

            buttonQuit.transform.DOScale(1f, showAnimationDuration)
                .SetDelay(showAnimationDuration / 3 * 2 )
                .From(0f, true)
                .SetEase(Ease.OutBack);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace TheDuckFlock
{
    public class UIManager : MonoSingleton<UIManager>, IUIEventsListener<int>
    {
        [SerializeField] private ResultsPopup resultsPopup;
        [SerializeField] private StartPopup startPopup;

        [SerializeField] private Transform UIRoot;
        [SerializeField] private GameObject indicatorsRoot;
        [SerializeField] private NestIndicator nestIndicator;

        private void Awake()
        {
            UIEventsManager.SetupListeners(this);
        }

        private void OnDestroy()
        {
            UIEventsManager.RemoveListeners();
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
        public void OnPlayButtonClick()
        {
            Debug.Log(name + " | OnPlayButtonClick()");

            HideResultScreen();

            GameplayEventsManager.DispatchEvent(GameplayEvent.StartGame);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowResultScreen()
        {
            ScoreManager.Instance.SwitchScoreVisibility(false);

            resultsPopup.RefreshValues();

            resultsPopup.ShowPopup();

            UIRoot.DOScale(1f, 1f).From(0, true).SetEase(Ease.OutBack);
        }

        public void HideResultScreen()
        {
            UIRoot.DOScale(0, 1f).SetEase(Ease.InBack).OnComplete( () =>
            {
                resultsPopup.HidePopup();
            });
           
        }
        
        public void SwitchIndicatorsVisibility(bool isVisible)
        {
            indicatorsRoot.SetActive(isVisible);

        }

        public void SetScoreGoal(int numberOfDuckies)
        {
            foreach (Transform child in indicatorsRoot.transform)
            {
                child.parent = ObjectPooler.Instance.PoolRoot;
                child.gameObject.SetActive(false);
            }

            for (int i = 0; i < numberOfDuckies; i++)
            {
                GameObject indicatorObject = ObjectPooler.Instance.SpawnFromPool(PoolTag.ScoreIndicator);
                indicatorObject.SetActive(true);
                indicatorObject.transform.parent = indicatorsRoot.transform;

                ScoreIndicator indicator = indicatorObject.GetComponent<ScoreIndicator>();
                indicator.IsAchieved = false;
                
            }

        }

        public void UpdateScore(int numberOfDuckies)
        {
            Debug.Log(name + " | Update score " + numberOfDuckies);

            for (int iChild = 0; iChild < indicatorsRoot.transform.childCount; iChild++)
            {
                ScoreIndicator indicator = indicatorsRoot.transform.GetChild(iChild).GetComponent<ScoreIndicator>();

                indicator.IsAchieved = iChild < numberOfDuckies;

                Debug.Log(name + " | indicator " + iChild + " " + (iChild < numberOfDuckies));
            }
        }

        public void SwitchNestIndicatorVisibility(bool isVisible)
        {
            nestIndicator.SwitchVisibility(isVisible);
        }

        #region UIEvent listeners

        public void OnCloseStartPopup(params int[] parameters)
        {
            startPopup.HidePopup();
            resultsPopup.ShowPopup();
        }

        public void OnShowResultsPopup(params int[] parameters)
        {
            
        }
        #endregion
    }
}

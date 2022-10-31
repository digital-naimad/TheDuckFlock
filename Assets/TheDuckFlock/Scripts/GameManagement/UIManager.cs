using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuckFlock
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private ResultsScreen resultsScreen;

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

            resultsScreen.SwitchVisibility(false);

            GameplayEventsManager.DispatchEvent(GameplayEvent.StartGame);
        }
    }
}

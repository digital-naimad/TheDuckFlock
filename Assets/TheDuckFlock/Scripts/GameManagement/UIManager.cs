using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuckFlock
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private Button startButton;

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
        public void OnStartButtonClick()
        {
            Debug.Log(name + " >> OnStartButtonClick()");

            startButton.gameObject.SetActive(false);
            GameManager.Instance.StartGame();
        }

    }
}

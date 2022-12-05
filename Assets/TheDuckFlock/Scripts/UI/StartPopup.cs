using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuckFlock
{
    public class StartPopup : PopupBase
    {
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnButtonPlayClick()
        {

            buttonPlay.gameObject.SetActive(false);

            UIEventsManager.DispatchEvent(UIEvent.CloseStartPopup);

        }

        
    }
}

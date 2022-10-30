using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheDuckFlock
{
    public class EggController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < WorldManager.Instance.LostEggThreshold)
            {
                GameplayEventsManager.DispatchEvent(GameplayEvent.EggLost);

                gameObject.SetActive(false);
            }
        }
    }
}

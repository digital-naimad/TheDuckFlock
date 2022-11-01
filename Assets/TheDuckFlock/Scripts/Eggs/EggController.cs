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

                Hide();
            }

            if (Vector3.Distance(transform.position, FlockManager.Instance.MotherPosition) < WorldManager.Instance.HatchEggThreshold)
            {
                GameplayEventsManager.DispatchEvent(GameplayEvent.EggHatched, transform.position);

                Hide();
            }
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

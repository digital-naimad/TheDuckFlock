
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuckFlock
{
    public class NestIndicator : MonoBehaviour
    {
        [SerializeField] private Image arrowImage;
        [SerializeField] private Image nestIcon;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (arrowImage.enabled)
            {
                UpdateArrow();
            }
        }

        public void SwitchVisibility(bool isVisible)
        {

            if (isVisible)
            {
                arrowImage.enabled = true;
                nestIcon.enabled = true;
            }
            arrowImage.transform.parent
                .DOScale(isVisible ? 1 : 0, 1f)
                .From(isVisible ? 0 : 1)
                .SetEase(isVisible ? Ease.OutBack : Ease.InBack)
                .OnComplete(() =>
                {
                    if (!isVisible)
                    {
                        arrowImage.enabled = false;
                        nestIcon.enabled = false;
                    }
                });
            
        }

        public void UpdateArrow()
        {

            arrowImage.transform.DOLookAt(FlockManager.Instance.MotherPosition, 1f);
        }

    }
}

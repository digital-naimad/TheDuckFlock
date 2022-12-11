using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

namespace TheDuckFlock
{
    public class ScreenFader : MonoSingleton<ScreenFader>
    {
        [SerializeField] private Image dimImage;
        [SerializeField] private Color dimColor = Color.black;

        [Range(.1f, 5f)]
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private Ease fadeEasing = Ease.InQuint;

        private void Awake()
        {
            if (dimImage == null)
            {
                dimImage = GetComponent<Image>();
            }

            InitDimColor();
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public void DoFade(bool isFadeIn, UnityAction onCompleteCallback = null)
        {
            if (dimImage != null)
            {
                dimImage.DOFade(isFadeIn ? 0f : 1f, fadeDuration)
                    .SetEase(fadeEasing)
                    .OnComplete(() =>
                    {
                        if (onCompleteCallback != null)
                        {
                            onCompleteCallback();
                        }
                    });


            }
        }

        private void InitDimColor()
        {
            dimImage.color = dimColor;
        }
    }
}

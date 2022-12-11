
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuckFlock
{
    public class NestIndicator : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask raycastLayerMask;

        [SerializeField] private Image arrowImage;
        [SerializeField] private Image nestIcon;

        private Vector3 IndicatorPosition
        {
            get { return nestIcon.rectTransform.position; }
        }

        // Start is called before the first frame update
        void Start()
        {
            //Debug.Log(name + " | nestIcon positon: " + nestIcon.rectTransform.position);
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

        public Vector2 testVector = Vector2.one;
        public float calculatedAngle;

        public void UpdateArrow()
        {
            Vector3 indicatorProjectedPosition = WorldManager.Instance.RaycastWorld(IndicatorPosition, raycastLayerMask);
           
            if (indicatorProjectedPosition != Vector3.zero)
            {

                float angle = CalculateArrowAngle(indicatorProjectedPosition);
                //Debug.Log(name + " | angle " + angle);
                arrowImage.transform.DORotate(new Vector3(0, 0, angle), .1f);
            }
        }

        private float CalculateArrowAngle(Vector3 indicatorProjectedPosition)
        {
            
            return MathUtils.GetAngleBetween2PointsInDegrees(
                indicatorProjectedPosition.x, 
                indicatorProjectedPosition.z,
                NestsManager.Instance.NestPosition.x, 
                NestsManager.Instance.NestPosition.z
                );
        }

    }
}

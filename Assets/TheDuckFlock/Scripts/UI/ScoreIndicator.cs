using UnityEngine;
using UnityEngine.UI;

namespace TheDuckFlock
{
    public class ScoreIndicator : MonoBehaviour
    {
        [SerializeField] private Texture notAchievedIndicatorTexture;
        [SerializeField] private Texture achievedIndicatorTexture;
        [SerializeField] private Image indicator;

        [SerializeField] private Sprite notAchievedIndicatorSprite;
        [SerializeField] private Sprite achievedIndicatorSprite;
        /// <summary>
        /// 
        /// </summary>
        public bool IsAchieved
        {
            set
            {
               indicator.sprite = value ? achievedIndicatorSprite : notAchievedIndicatorSprite;
            }
        }

        private void Awake()
        {
           
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        
    }
}

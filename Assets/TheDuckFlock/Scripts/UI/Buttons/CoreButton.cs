using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TheDuckFlock
{ 
    public class CoreButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [SerializeField] private Sprite onSprite;
        [SerializeField] private Sprite offSprite;

        [SerializeField] private UnityAction onClick;

        [SerializeField] protected bool isOn = true;

        

        private void Awake()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
        }

        public void SwitchState()
        {
            isOn = !isOn;
        }

        public void ChangeSprite()
        {
            _button.image.sprite = isOn ? onSprite : offSprite;
        }

       
    }
}

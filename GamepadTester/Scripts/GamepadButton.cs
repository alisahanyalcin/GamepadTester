using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamepadTester
{
    public class GamepadButton : MonoBehaviour
    {
        private GamepadUIManager _gamepadUiManager;
        
        public Slider slider;
        public Image image;
        public TMP_Text text;
        
        private void Awake()
        {
            _gamepadUiManager = FindObjectOfType<GamepadUIManager>();
        }
    
        public void SetSliderValue(float value)
        {
            var lerpValue = Mathf.Lerp(slider.value, value, Time.deltaTime * 20f);
            slider.value = lerpValue;
            if (image != null)
            {
                image.color = Color.Lerp(_gamepadUiManager.normalColor, _gamepadUiManager.activeColor, lerpValue);
            }
            
            text.text = value.ToString("F");
        }
        
        public void SetStickValue(Vector2 value)
        {
            var x = Mathf.Clamp(value.x * 35f, -35f, 35f);
            var y = Mathf.Clamp(value.y * 35f, -35f, 35f);
            var rectTransform = image.GetComponent<RectTransform>();
            var childImage = image.transform.GetChild(0);
            
            rectTransform.anchoredPosition = new Vector2(x, y);
            
            if (value == Vector2.zero)
            {
                childImage.gameObject.SetActive(false);
                return;
            }
            childImage.gameObject.SetActive(true);
        }
    }
}
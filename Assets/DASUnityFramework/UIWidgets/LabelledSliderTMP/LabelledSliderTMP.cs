using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DASUnityFramework.UIWidgets.LabelledSliderTMP
{
    public class LabelledSliderTMP : MonoBehaviour
    {

        public Slider slider;
        public TextMeshProUGUI nameLabel;
        public TextMeshProUGUI max;
        public TextMeshProUGUI min;
        public TextMeshProUGUI currentValue;


        private void Awake()
        {
            SetRange(slider.minValue, slider.maxValue);
        }

        public void OnValueChanged(float value)
        {
            currentValue.text = "" + RoundOff(value);
        }
        public void SetRange(float minimum, float maximum)
        {
            slider.maxValue = maximum;
            slider.minValue = minimum;

            max.text = "" + RoundOff(maximum);
            min.text = "" + RoundOff(minimum);
            OnValueChanged(slider.value);
        }
        private float RoundOff(float num)
        {
            return ((int)(num*10))/10f;
        }
    }
}

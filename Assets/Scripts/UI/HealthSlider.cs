using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void setMaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void decrementHealthSlider(float value)
    {
        slider.value = value;
    }
}

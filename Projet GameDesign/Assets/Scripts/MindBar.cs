using UnityEngine;
using UnityEngine.UI;

public class MindBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxMind(int mind)
    {
        slider.maxValue = mind;
        slider.value = mind;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetMind(int mind)
    {
        slider.value = mind;


        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void LoseOneMind()
    {
        if (slider.value > 0) {
            slider.value -= 1;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}

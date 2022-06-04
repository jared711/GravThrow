using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sliderController : MonoBehaviour
{
    public Slider sliderUI;
    public TextMeshProUGUI valueText;

    void Update()
    {
        valueText.text = sliderUI.value.ToString();
    }

    public void onSliderChanged(float value)
    {
        Debug.Log(value);
        valueText.text = value.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SliderControl : MonoBehaviour
{
    Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }

    public  void SliderValue(int maxValue,int currentValue)
    {
        int sliderValue = maxValue - currentValue;
        slider.maxValue = maxValue;
        slider.value = sliderValue;
    }
    
}

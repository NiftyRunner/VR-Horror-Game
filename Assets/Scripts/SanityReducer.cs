using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityReducer : MonoBehaviour
{
    public float sliderValue;
    [SerializeField] float reductionValue = 0.3f;
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
        sliderValue = slider.value;
    }

    void Update()
    {
        slider.value = slider.value - reductionValue * Time.deltaTime;
        sliderValue = slider.value;
    }
}

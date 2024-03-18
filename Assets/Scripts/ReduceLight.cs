using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class ReduceLight : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Slider slider;
    [SerializeField] float reductionValue;
    [SerializeField] float reductionMultiplier = 10;

    void Start()
    {
        light = GetComponentInChildren<Light>();
        light.intensity = 10;
    }

    void Update()
    {
        reductionValue = slider.value * reductionMultiplier;
        light.intensity = reductionValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    Slider progressBar;

    void Awake()
    {
        progressBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        Sun.OnSunChanged += UpdateSlider;
    }

    private void OnDisable()
    {
        Sun.OnSunChanged -= UpdateSlider;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSlider(float sliderAmount)
    {
        float sliderPercent = sliderAmount / 10;
        progressBar.value = sliderPercent;
    }
}

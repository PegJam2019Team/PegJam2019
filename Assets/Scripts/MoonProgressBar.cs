using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//I've committed the greatest of code duplication sins and I don't care right now!
public class MoonProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    Slider progressBar;

    void Awake()
    {
        progressBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        Moon.OnMoonChanged += UpdateSlider;
    }

    private void OnDisable()
    {
        Moon.OnMoonChanged -= UpdateSlider;
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

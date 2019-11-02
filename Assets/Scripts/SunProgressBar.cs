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
        
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

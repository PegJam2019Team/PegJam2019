using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [Range(1, 10)]
    private float closeness;

    float neglectTime = 10;
    float neglectTimer = 0;

    public delegate void SunChangedDelegate(float newValue);
    public static event SunChangedDelegate OnSunChanged;

    private void OnEnable()
    {
        Wanderer.OnCollectWanderer += AddValue;
    }

    private void OnDisable()
    {
        Wanderer.OnCollectWanderer -= AddValue;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (neglectTimer >= neglectTime)
        {
            closeness -= Time.deltaTime * 0.05f;
        }
    }

    void AddValue(bool isDark)
    {
        if (!isDark)
        {
            ChangeCloseness(1);
            neglectTimer = 0;
        }
    }

    void ChangeCloseness(float amount)
    {
        closeness += amount;

        if (OnSunChanged != null)
        {
            OnSunChanged(closeness);
        }
    }
}

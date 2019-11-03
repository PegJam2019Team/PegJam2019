using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [Range(0, 13)]
    public float closeness;

    float neglectTime = 15;
    float neglectTimer = 0;

    public delegate void MoonChangedDelegate(float newValue);
    public static event MoonChangedDelegate OnMoonChanged;

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
            ChangeCloseness(-Time.deltaTime * 0.25f);
        }

        neglectTimer += Time.deltaTime;

        Vector3 newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, -110 + (closeness * 4));
        transform.localPosition = newPos;

        float scale = 10 + (closeness * 4);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void AddValue(bool isDark)
    {
        if (isDark)
        {
            neglectTimer = 0;
            ChangeCloseness(1);
        }
    }

    
    void ChangeCloseness(float amount)
    {
        closeness += amount;

        if (closeness < 0)
        {
            closeness = 0;
        }

        if(closeness > 13)
        {
            closeness = 13;
        }

        if (OnMoonChanged != null)
        {
            OnMoonChanged(closeness);
        }
    }
}

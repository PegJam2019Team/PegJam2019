using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [Range(0, 10)]
    public float closeness;

    float neglectTime = 25;
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


        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, -60 + (closeness * 2));

        transform.localPosition = newPos;

        if (OnMoonChanged != null)
        {
            OnMoonChanged(closeness);
        }
    }
}

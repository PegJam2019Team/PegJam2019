using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float speedX = 0.1f, speedY = 1, speedZ = 0;
    new Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Mathf.Sin(speedX * Time.timeSinceLevelLoad), speedY, speedZ);
        
    }
}

using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    private Transform camTransform;

    // How long the object should shake for.
    public float shake = 1f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;

    private bool doShake = false;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        //shakeAmount = Mathf.Abs(laserBall.transform.position.x) / 25f;

        //if (shake > 0)
        //{
        if (doShake)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            //shakeAmount -= Time.deltaTime;
        }

        if (shakeAmount <= 0)
        {
            doShake = false;
        }

        //shake -= Time.deltaTime * decreaseFactor;
        //}
        //else
        //{
        //    shake = 0f;
        //    camTransform.localPosition = originalPos;
        //}
    }

    public void DoShake(float amount)
    {
        doShake = true;
        shakeAmount = amount;
    }
}
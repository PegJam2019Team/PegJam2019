using UnityEngine;
using System.Collections;
using Cinemachine;
public class Shake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    private CinemachineComposer camComposer;

    // How long the object should shake for.
    //public float shake = 1f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;

    private bool doShake = false;

    Vector3 originalPos;

    void Start()
    {
        if (camComposer == null)
        {
            camComposer = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
            originalPos = camComposer.m_TrackedObjectOffset;
        }
    }

    void OnEnable()
    {
        
    }

    void Update()
    {
        //shakeAmount = Mathf.Abs(laserBall.transform.position.x) / 25f;

        //if (shake > 0)
        //{
        if (doShake)
        {
            camComposer.m_TrackedObjectOffset = originalPos + Random.insideUnitSphere * shakeAmount;
            camComposer.m_DeadZoneHeight = 2 - (shakeAmount * 2);
            camComposer.m_DeadZoneWidth = 2 - (shakeAmount * 2);
            

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
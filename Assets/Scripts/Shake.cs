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
            shakeAmount /= 5f;
            camComposer.m_TrackedObjectOffset = originalPos + Random.insideUnitSphere * shakeAmount;
            if (shakeAmount > 0)
            {
                camComposer.m_DeadZoneHeight = 0f;
                camComposer.m_DeadZoneWidth = 0f;
            }
            else
            {
                camComposer.m_DeadZoneHeight = 0.2f;
                camComposer.m_DeadZoneWidth = 0.2f;
            }
            //camComposer.m_DeadZoneHeight = 0.2f - (shakeAmount * 0.2f);
            //camComposer.m_DeadZoneWidth = 0.2f - (shakeAmount * 0.2f);


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
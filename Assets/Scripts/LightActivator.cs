using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivator : MonoBehaviour
{
    public bool isDark;
    private float dotToOther;
    bool active = false;
    
    Transform sun;
    Renderer rend;
    ParticleSystem particles;
    ParticleSystem.EmissionModule emission;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        particles = GetComponent<ParticleSystem>();
        rend = GetComponent<Renderer>();

        emission = particles.emission;
    }

    void Start()
    {
        sun = FindObjectOfType<Sun>().transform;
        emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toOther = sun.position - transform.position;

        dotToOther = Vector3.Dot(transform.up, toOther.normalized);

        active = (isDark) ? dotToOther > -0.4f : dotToOther < -0.5f;

        //rend.enabled = active;

        //Debug.Log(active);

        if (active)
        {
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }
}

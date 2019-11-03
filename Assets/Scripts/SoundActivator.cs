using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivator : MonoBehaviour
{
    public bool isDark;
    private float dotToOther;
    bool active = false;

    public bool Active { get => active; }

    Transform sun;
    AudioSource audio;

    public float transitionTime = 2f;
    float timer = 0f;

    void Awake()
    {
        //rend = GetComponent<Renderer>();
        audio = GetComponent<AudioSource>();
        audio.volume = 0f;
    }

    void Start()
    {
        sun = FindObjectOfType<Sun>().transform;
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
            timer += Time.deltaTime;

            audio.volume = Mathf.Lerp(0, 1, timer);
        }
        else
        {
            timer += Time.deltaTime;
            audio.volume = Mathf.Lerp(1, 0, timer);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }

    public IEnumerable FadeMusic(float time)
    {
        yield return null;
    }
}

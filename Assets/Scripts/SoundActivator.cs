using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivator : MonoBehaviour
{
    public bool isDark;
    private float dotToOther;
    bool active = false;
    bool wasActive = false;

    public bool Active { get => active; }

    Transform sun;
    public AudioSource audioDay, audioNight;

    public float transitionTime = 2f;
    float timer = 0f;

    private IEnumerator fadeInDay;
    private IEnumerator fadeOutDay;
    private IEnumerator fadeInNight;
    private IEnumerator fadeOutNight;

    void Awake()
    {
        //rend = GetComponent<Renderer>();
        //audio = GetComponent<AudioSource>();
        audioDay.volume = 0f;
        audioNight.volume = 0f;
    }

    void Start()
    {
        sun = FindObjectOfType<Sun>().transform;
        fadeInDay = FadeMusic(true, audioDay);
        fadeOutDay = FadeMusic(false, audioDay);
        fadeInNight = FadeMusic(true, audioNight);
        fadeOutNight = FadeMusic(false, audioNight);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toOther = sun.position - transform.position;

        dotToOther = Vector3.Dot(transform.up, toOther.normalized);

        active = (isDark) ? dotToOther > -0.4f : dotToOther < -0.5f;

        if (active)
        {
            //StopCoroutine(fadeInNight);
            //StopCoroutine(fadeOutDay);

            //StartCoroutine(fadeInDay);
            //StartCoroutine(fadeOutNight);
            audioDay.volume += Time.deltaTime / transitionTime;
            audioNight.volume -= Time.deltaTime / transitionTime;
            //timer += Time.deltaTime;

            //audio.volume = Mathf.Lerp(0, 1, timer);
        }
        else
        {
            //StopCoroutine(fadeInDay);
            //StopCoroutine(fadeOutNight);

            //StartCoroutine(fadeInNight);
            //StartCoroutine(fadeOutDay);
            audioDay.volume -= Time.deltaTime / transitionTime;
            audioNight.volume += Time.deltaTime / transitionTime;
            //timer += Time.deltaTime;
            //audio.volume = Mathf.Lerp(1, 0, timer);
        }

        //if(timer >= transitionTime)
        //{
        //    timer = 0;
        //}
    }

    public IEnumerator FadeMusic(bool fadeIn, AudioSource audio)
    {
        for (float ft = 0; ft >= 1f; ft += 0.1f / transitionTime)
        {
            if (fadeIn)
            {
            audio.volume = ft;
            }
            else
            {
                audio.volume = 1 - ft;
            }
            yield return new WaitForSeconds(ft);
        }
    }
}

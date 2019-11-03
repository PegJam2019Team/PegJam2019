using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndState : MonoBehaviour
{
    Sun sun;
    Moon moon;
    Rotater rotator;
    Camera cam;
    Shake shake;
    // Start is called before the first frame update
    void Start()
    {
        sun = FindObjectOfType<Sun>();
        moon = FindObjectOfType<Moon>();
        rotator = FindObjectOfType<Rotater>();
        cam = FindObjectOfType<Camera>();
        shake = FindObjectOfType<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sun.closeness >= 10 && moon.closeness >= 10)
        {
            //end the game!
            //Debug.Log("You win!");
            SceneManager.LoadScene(0);
        }

        if(sun.closeness >= 13 || moon.closeness >= 13)
        {
            //Debug.Log("Crash Into Planet!");
            SceneManager.LoadScene(0);
        }

        float shakeAmount = 0f;
        if (sun.closeness > 10)
        {
            shakeAmount = ((sun.closeness - 10) / 3);
        }
        if (moon.closeness > 10)
        {
            shakeAmount = ((moon.closeness - 10) / 3);
        }

        shake.DoShake(shakeAmount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : MonoBehaviour
{
    Sun sun;
    Moon moon;
    Rotater rotator;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        sun = FindObjectOfType<Sun>();
        moon = FindObjectOfType<Moon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sun.closeness == 10 && moon.closeness == 10)
        {
            //end the game!
            Debug.Log("You win!");
        }

        if(sun.closeness >= 13 || moon.closeness >= 13)
        {
            Debug.Log("Crash Into Planet!");
        }
    }
}

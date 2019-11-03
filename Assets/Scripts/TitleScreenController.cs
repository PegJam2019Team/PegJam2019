using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MonoBehaviour


{
    private bool titleCanvas = true;
    private bool storyCanvas_1 = true;
    private bool storyCanvas_2 = true;
    private bool storyCanvas_3 = true;
    private bool controlCanvas = true;
    private bool mechanicCanvas = true;

    public GameObject Planet;

    private bool isRotate;

    //public Animator animTitle_Alpha;
    //public Animator storyCanvas_1_Alpha;

    //public AnimationClip fadeTitleAlphaAnimationClip;		//Animation clip fading out UI elements alpha


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            //FADE
        }
    }
}

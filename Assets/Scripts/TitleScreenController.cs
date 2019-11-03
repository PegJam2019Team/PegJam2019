using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour


{

    public Image[] images;
    public GameObject title;
    private int index = -1;
    public Image backPanel;
    //private bool titleCanvas = true;
    //private bool storyCanvas_1 = true;
    //private bool storyCanvas_2 = true;
    //private bool storyCanvas_3 = true;
    //private bool controlCanvas = true;
    //private bool mechanicCanvas = true;

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
        if (Input.anyKeyDown)
        {
            title.SetActive(false);
            backPanel.color = new Color(1, 1, 1, 0.9f);

            if (index == images.Length - 1)
            {
                SceneManager.LoadScene(1);
                return;
            }

            if (index > -1)
            {
                images[index].color = Color.clear;
            }
            index++;
            images[index].color = Color.white;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeEnd : MonoBehaviour
{
    public string ControllerButton;

    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown(ControllerButton))
        {
            FadeManager.FadeOut("title");
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public string ControllerButton;
    public string NextScene;

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
            FadeManager.FadeOut(NextScene);
        }
    }
}

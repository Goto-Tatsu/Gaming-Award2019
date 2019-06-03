using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_to_Stageselect : MonoBehaviour
{
    // Start is called before the first frame update
    public string stagename;

    public void OnClick()
    {
        FadeManager.FadeOut(stagename);
        //SceneManager.LoadScene(stagename);
    }
}

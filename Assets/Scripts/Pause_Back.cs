using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Back : MonoBehaviour
{
    // Start is called before the first frame update

    public string StageName;

    public void OnClick()
    {
        SceneManager.LoadScene(StageName);   
    }
}

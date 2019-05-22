using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_by_Keyboard : MonoBehaviour
{
    public GameObject SoundManager;
    public Audio m_audio;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GameObject.FindGameObjectWithTag("SoundManager");
        m_audio = SoundManager.GetComponent<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) { transform.position -= new Vector3(1, 0, 0); }
        else if (Input.GetKey(KeyCode.D)) { transform.position += new Vector3(1, 0, 0); }
        else if (Input.GetKey(KeyCode.W)) { transform.position += new Vector3(0, 1, 0); }
        else if (Input.GetKey(KeyCode.S)) { transform.position -= new Vector3(0, 1, 0); }
    }
}

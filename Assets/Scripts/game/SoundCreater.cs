using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCreater : MonoBehaviour
{

    public GameObject SoundManeger;
    private Audio m_audio;
    

    // Start is called before the first frame update
    void Start()
    {
        m_audio = SoundManeger.GetComponent<Audio>();

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            m_audio.PlaySound(4);
        }
        else if (collider.gameObject.tag == "Balloon")
        {
            m_audio.PlaySound(1); // SE_Bomb
        }
    }
}

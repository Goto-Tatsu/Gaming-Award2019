using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource m_audioSource;
    private Audio m_audio;

    //public Status status;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Coin";
        this.gameObject.AddComponent<AudioSource>();
        m_audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Normal_coinを消す
            //m_audio.PlayerSound(3);
            Destroy(gameObject.transform.parent.parent.parent.gameObject);
        }
    }

}

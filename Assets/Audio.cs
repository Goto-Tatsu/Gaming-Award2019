using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public List<AudioClip> audioClip = new List<AudioClip>();
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        if(audioClip.Count < index)
        {
            return;
        }
        audioSource.clip = audioClip[index];

        audioSource.PlayOneShot(audioClip[index]);
    }

}

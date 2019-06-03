using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishcontroll : MonoBehaviour
{
    Animation anim;

    // Use this for initialization
    void Start()
    {
        Animation anim = gameObject.GetComponent<Animation>();
        //anim = this.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play();
    }
}
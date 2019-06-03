using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_vs_Player : MonoBehaviour
{
    private bool destroy_flg;
    // Start is called before the first frame update
    void Start()
    {
        destroy_flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            destroy_flg = true;
        }
    }

    public bool Get_Destroy_Flg { get { return destroy_flg; } }
}

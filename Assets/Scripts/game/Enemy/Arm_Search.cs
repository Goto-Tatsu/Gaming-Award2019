using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Search : MonoBehaviour
{

    private bool search;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            search = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            search = false;
        }
    }

    public bool GEt_Serach { get { return search; } }
}

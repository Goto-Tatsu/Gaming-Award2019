using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Attack : MonoBehaviour
{
    private bool attack;
    public Armed_bal Arm_Ba;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(attack);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            attack = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                attack = false;
        }
    }

    public bool Get_Attack { get { return attack; } }
}

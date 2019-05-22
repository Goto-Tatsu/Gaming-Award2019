using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private float fMove;
    private bool bSwitch;

    // Start is called before the first frame update
    void Start()
    {
        fMove = 1;
        bSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bSwitch)
        {
            transform.position += new Vector3(0, fMove, 0);
            fMove += 0.5f;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //衝突判定
        if (collision.gameObject.tag == "Player")
        {
            bSwitch = true;
        }
    }
}

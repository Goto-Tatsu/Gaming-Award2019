using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Title : MonoBehaviour
{
    public float speed;
    private Vector3 hitPos;
    private bool walk_flg;
    private bool pon;
    new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        walk_flg = false;
        pon = false;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walk_flg == true)
        {
            transform.RotateAround(hitPos, Vector3.forward, speed);
        }

        if(pon==true)
        {
            walk_flg = false;
        }
        Debug.Log(pon);
    }

    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            if (pon == false)
            {
                walk_flg = true;
                foreach (ContactPoint point in collision.contacts)
                {
                    hitPos = point.point;
                    //Debug.Log(hitPos);
                    //transform.LookAt(hitPos);
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            pon = true;
            rigidbody.AddForce(0.0005f, 0.0001f, 0);
            Debug.Log("hit");
        }
    }

    public bool Get_Pon { get { return pon; } }
}

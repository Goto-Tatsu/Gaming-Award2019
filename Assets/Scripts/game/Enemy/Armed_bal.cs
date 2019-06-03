using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armed_bal : MonoBehaviour
{
    public float move_max;
    public float speed;
    private bool move_flg;

    private Animator animator;
    public Arm_vs_Player AvP;
    private float i;
    private GameObject collider_child;
    public Arm_Search Arm_Se;
    public Arm_Attack Arm_At;
    private float Anim_cnt;
    private Vector3 stock;
    private bool anim_finish;
    // Start is called before the first frame update
    void Start()
    {
        move_flg = false;
        collider_child = GameObject.Find("Collider_Arm");
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Arm_At.Get_Attack == false && anim_finish == false)
        {

            animator.SetBool("Attack", false);
            animator.speed = 1.0f;
            if (move_flg == false)
            {
                if (Arm_Se.GEt_Serach == false)
                {
                    transform.position -= new Vector3(speed, 0.0f, 0.0f);
                    i += speed;
                }
                if (Arm_Se.GEt_Serach == true)
                {
                    transform.position -= new Vector3(speed * 2.0f, 0.0f, 0.0f);
                    i += speed * 2.0f;
                    animator.speed = 3.0f;
                }
                if (i >= move_max)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    move_flg = true;
                    i = 0;
                }
            }

            if (move_flg == true)
            {
                if (Arm_Se.GEt_Serach == false)
                {
                    transform.position += new Vector3(speed, 0.0f, 0.0f);
                    i += speed;
                }
                if (Arm_Se.GEt_Serach == true)
                {
                    animator.speed = 3.0f;
                    transform.position += new Vector3(speed * 2.0f, 0.0f, 0.0f);
                    i += speed * 2.0f;
                }
                if (i >= move_max)
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    move_flg = false;
                    i = 0;
                }
            }
        }

        if(Arm_At.Get_Attack==true)
        {
            anim_finish = true;   
        }

        if(anim_finish == true)
        {
            animator.speed = 1.0f;
            animator.SetBool("Attack", true);
            if (move_flg == false)
            {
                collider_child.transform.position -= new Vector3(0.15f, 0, 0);
            }
            if (move_flg == true)
            {
                collider_child.transform.position += new Vector3(0.15f, 0, 0);
            }

            if (Anim_cnt == 0)
            {
                stock = collider_child.transform.position;
            }

            Anim_cnt++;
            if(Anim_cnt > 120)
            {
                animator.SetBool("Attack", false);
                collider_child.transform.position = stock;
                anim_finish = false;
            }
        }
        if(anim_finish==false)
        {
            Anim_cnt = 0;
        }
    }

    public bool Get_Anim_Fin { get { return anim_finish; } }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcontroll : MonoBehaviour
{
    /*public float movementSpeed;
    public bool balloon_flag;
    int time;


    void Start()
    {
        balloon_flag = false;
        time = 0;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * movementSpeed;
        }
        if (balloon_flag == true)
        {
            transform.position -= transform.right * movementSpeed;
        }
        if (balloon_flag == false)
        {
            transform.position += transform.right * movementSpeed;
        }

        if (time == 200)
        {
            if (balloon_flag == true)
            {
                balloon_flag = false;
                time = 0;
            }
        }
        if (time == 200)
        {
            if (balloon_flag == false)
            {
                balloon_flag = true;
                time = 0;
            }
        }
        time++;
    }*/

    public int posX;        //初期ポジションＸ
    public int posY;        //初期ポジションＹ
    public float speed;     //スピード
    public float width;     //円の横幅
    public float height;    //円の縦幅


    void Update()
    {
        float x = Mathf.Cos(Time.time * speed) * width;
        float y = Mathf.Sin(Time.time * speed) * height;

        transform.position = new Vector3(x + posX, y + posY, 0);
    }


    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("player"))
        {
            Destroy(this.gameObject);
        }
    }
}
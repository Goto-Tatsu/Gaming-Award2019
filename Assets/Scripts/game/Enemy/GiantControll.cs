using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantControll : MonoBehaviour
{
    public float speed;
    public float interval;
    public float fall_speed;
    public float move;
    private int move_flg;
    private float i;
    private float j;
    private float hight;
    private float width;
    private GameObject Giant;
    private Vector3 first;
    // Start is called before the first frame update
    void Start()
    {
        move_flg = 0;
        Giant = GameObject.Find("BigFoot");
        first = Giant.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg == 0)
        {
            if (j < interval)
            {
                j++;
            }
            else
            {
                transform.position += new Vector3(-speed, speed * 1.5f, 0);

                if (i < move)
                {
                    i += speed;
                    hight = i * 1.4f;
                    width = i;
                }
                else
                {
                    i = 0;
                    j = 0;
                    move_flg = 1;
                }
            }
        }

        if (move_flg == 1)
        {
            if (j < interval)
            {
                j++;
            }
            else
            {
                transform.position += new Vector3(0, -fall_speed, 0);

                if (i <= hight)
                {
                    i += fall_speed;
                }
                else
                {
                    j = 0;
                    i = 0;
                    move_flg = 2;
                }
            }
        }

        if (move_flg == 2)
        {
            if (j < interval)
            {
                j++;
            }
            else
            {
                transform.position += new Vector3(speed, speed * 1.2f, 0);

                if (i <= width)
                {
                    i += speed;
                }
                else
                {
                    j = 0;
                    i = 0;
                    move_flg = 3;
                }
            }
        }

        if (move_flg == 3)
        {
            if (j < interval)
            {
                j++;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, first, Time.deltaTime * 10.0f);

                
                if(transform.position == first)
                {
                    j = 0;
                    i = 0;
                    move_flg = 0;
                }


            }
        }
    }
}

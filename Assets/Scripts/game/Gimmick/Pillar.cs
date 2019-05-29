using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public float speed;         //伸び縮みの速さ
    public float interval;      //フラグ切り替えの間隔
    public float fall;          //落ちる距離

    
    private bool press;         //下がり上がりフラグ
    private float counter;
    private float i;
    // Start is called before the first frame update
    void Start()
    {
        press = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (press == false)
        {
            if (i < fall)
            {
                i += speed;
                transform.localScale += new Vector3(0.0f, speed, 0.0f);
            }
            Debug.Log(fall);
            if (i >= fall)
            {
                //transform.position += new Vector3(0.0f, 0.0f, 0.0f);
                counter++;
                if (counter > interval)
                {
                    press = true;
                    counter = 0;
                    i = 0;
                }
            }
        }

        if (press == true)
        {
            if (i < fall)
            {
                i += speed;
                transform.localScale += new Vector3(0.0f, -speed, 0.0f);
            }
            if (i >= fall)
            {
                //transform.position += new Vector3(0.0f, 0.0f, 0.0f);
                counter++;
                if (counter > interval)
                {
                    press = false;
                    counter = 0;
                    i = 0;
                }
            }
        }
    }

    public bool Get_Press { get { return press; } }

    public float Get_Cnt { get { return i; } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{

    public Pres_Pillar press_pillar;
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
            if (i < press_pillar.Get_Fall)
            {
                i += press_pillar.Get_Speed;
                transform.localScale += new Vector3(0.0f, press_pillar.Get_Speed, 0.0f);
            }
            Debug.Log(press_pillar.Get_Fall);
            if (i >= press_pillar.Get_Fall)
            {
                //transform.position += new Vector3(0.0f, 0.0f, 0.0f);
                counter++;
                if (counter > press_pillar.Get_Interval)
                {
                    press = true;
                    counter = 0;
                    i = 0;
                }
            }
        }

        if (press == true)
        {
            if (i < press_pillar.Get_Fall)
            {
                i += press_pillar.Get_Speed;
                transform.localScale += new Vector3(0.0f, -press_pillar.Get_Speed, 0.0f);
            }
            if (i >= press_pillar.Get_Fall)
            {
                //transform.position += new Vector3(0.0f, 0.0f, 0.0f);
                counter++;
                if (counter > press_pillar.Get_Interval)
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

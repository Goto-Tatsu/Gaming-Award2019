using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    public Pres_Pillar press_pillar;
    public Pillar pillar;
    public float PistonPosperFrame;
    public float Counter_Max;

    private GameObject trace = null;
    private float counter;
    private float i;

    // Update is called once per frame
    void Update()
    {
        if (pillar.Get_Press == false)
        {
            if (pillar.Get_Cnt < press_pillar.Get_Fall)
            {
                transform.position += new Vector3(0.0f, -press_pillar.Get_Speed * 5.0f, 0.0f);
            }
        }

        if (pillar.Get_Press == true)
        {
            if (pillar.Get_Cnt < press_pillar.Get_Fall)
            {
                transform.position += new Vector3(0.0f, press_pillar.Get_Speed * 5.0f, 0.0f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharp_Rarm_shrink : MonoBehaviour
{
    new Rigidbody rigidbody;
    double Fixat = 0;    //伸び計算用
    public sharp_Rarm Rarm;
    public player player;
    bool pare_trans = false;
    bool shrink = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pare_trans = false;
        shrink = false;
    }

    // Update is called once per frame
    void Update()
    {


        //transform.localScale = new Vector3(1, 1 - (float)Fixat, 1);

        if (Rarm.Get_Cling() == true)
        {
            shrink = true;
        }

        if (shrink == true)
        {
            if (player.Get_ControX() < 0.4 && player.Get_ControX() > -0.4 && player.Get_ControY() < 0.4 && player.Get_ControY() > -0.4)
            {

                pare_trans = true;


                if (Rarm.Get_Fixation() <= 0)
                {
                    shrink = false;
                }
            }
        }

        if (shrink == false)
        {
            pare_trans = false;
        }

    }

    public bool Get_PareTrans { get { return pare_trans; } }

    public bool Get_Shrink { get { return shrink; } }

}

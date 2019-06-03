using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Clear : MonoBehaviour
{
    private bool Clear_flg;
    public float speed;
    public player player;
    private Vector3 RotCenter;
    public GoalFlag1 goalFlag;

    public float counter;//飛ぶまでの時間
    private int i;
    private float wait_cnt;
    private bool rocket;
    private bool Rigid_flg;
    public bool clear_ver;//転がるか飛ぶか
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        Clear_flg = false;
        rocket = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //ゲームクリア時の床には、スポンジブロックを配置して
       if(goalFlag.Get_Goal())
        {
            Clear_flg = true;
        }
        Debug.Log(goalFlag.Get_Goal());

       if(Clear_flg == true)
        {
            i++;

            Rigid_flg = true;
            if(Rigid_flg==true)
            {
                //加速度と回転無効
                //GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            if (i < counter)
            {
                transform.RotateAround(player.Get_hitPos, Vector3.forward, -speed);
            }

            if(i > counter)
            {
                Rigid_flg = false;
                wait_cnt++;
                if(wait_cnt >= 40)
                {
                    rocket = true;
                    FadeManager.FadeOut("StageSelect");
                }
            }


            if (rocket == true)
            {
                if (clear_ver == false)
                {
                    //上に飛ぶ
                    GetComponent<Rigidbody>().useGravity = false;
                    GetComponent<Rigidbody>().AddForce(0, 800, 0);
                    count++;

                    if(count>=120)
                    {
                        FadeManager.FadeOut("StageSelect");
                        count = 0;
                        rocket = false;
                    }
                }

                if(clear_ver==true)
                {
                    transform.RotateAround(player.Get_hitPos, Vector3.forward, -speed);
                    count++;

                    if (count >= 120)
                    {
                        FadeManager.FadeOut("StageSelect");
                        count = 0;
                        rocket = false;
                    }

                }
            }
        }
    }

    public bool Get_Rocket { get { return rocket; } }

}

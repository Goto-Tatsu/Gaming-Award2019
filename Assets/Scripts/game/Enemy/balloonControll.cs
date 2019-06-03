using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonControll : MonoBehaviour
{
    //Rigitなし
    public float StartPosX;        //初期ポジションＸ
    public float StartPosY;        //初期ポジションＹ
    public float speed;            //スピード
    float width;                   //横移動幅
    public float height;           //縦移動幅

    public bool left = false;      //左に進んでるか
    float time;                    //計測開始
    public int TimeChange;         //切り替わる時間

    private Animator animator;
    public Balloon_vs_Player BvP;

    private float counter;
    void Start()
    {
        //transform.position = new Vector3(StartPosX, StartPosY, 0.0f);

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (BvP.Get_Destroy_Flg == false)
        {
            animator.SetBool("Bom", false);

            transform.position = new Vector3(width / 40 + StartPosX, Mathf.Sin(Time.time * speed) * height + StartPosY, 0);

            if (left == false)
            {
                width++;
            }
            if (left == true)
            {
                width--;
            }

            if (time >= TimeChange)
            {
                if (left == true)
                {
                    left = false;
                }
                else
                if (left == false)
                {
                    left = true;
                }

                time = 0;

            }
            time++;
        }

        if (BvP.Get_Destroy_Flg == true)
        {
            animator.SetBool("Bom", true);
            counter++;

            if(counter >= 15)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
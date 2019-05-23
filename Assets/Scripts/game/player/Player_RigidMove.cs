using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RigidMove : MonoBehaviour
{

    public player own;            //プレイヤー情報取得
    public sharp_top top;         //プレイヤー情報取得
    public sharp_top_shrink top_shrink;
    public sharp_Rarm Rarm;       //プレイヤー情報取得
    public sharp_Rarm_shrink Rarm_shrink;
    public sharp_Larm Larm;       //プレイヤー情報取得
    public sharp_Larm_shrink Larm_shrink;
    public sharp_Rleg Rleg;       //プレイヤー情報取得
    public sharp_Rleg_shrink Rleg_shrink;
    public sharp_Lleg Lleg;       //プレイヤー情報取得
    public sharp_Lleg_shrink Lleg_shrink;


    public float player_speed;
    public float player_max_speed;
    public float player_max_speed_half;
    public float jump_power;        // ジャンプ力
    public float execute_wall;      // 壁から離れる距離
    public string Button_B;         // 対応するコントローラーの[B]ボタン
    public string Button_RStick;    // 対応するコントローラーの[Rstick]ボタン
    public float Distance_division; // distanceをどのくらい割る(division)か。デフォルト値は[2]。
    public float FrameSpeed;        // 


    public Trace GoldFish;
    new Rigidbody rigidbody;
    Vector3 distance;           //プレイヤの縮む距離
    private bool top_trans = false;         //プレイヤが縮むflg
    private bool Rarm_trans = false;         //プレイヤが縮むflg
    private bool Rleg_trans = false;         //プレイヤが縮むflg
    private bool Larm_trans = false;         //プレイヤが縮むflg
    private bool Lleg_trans = false;         //プレイヤが縮むflg
    private bool JumpFlg;
    private double Jump_FrameCnt;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        top_trans = false;
        Rarm_trans = false;
        Rleg_trans = false;
        Larm_trans = false;
        Lleg_trans = false;
        JumpFlg = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (own.Get_Kinema() == false)
        {

            if (own.Get_ControLeftX() < -0.8 || Input.GetKey(KeyCode.A))
            {
                if (rigidbody.velocity.magnitude <= player_max_speed)
                {
                    //左に傾いている
                    rigidbody.AddForce(-player_speed, 0, 0);
                }
            }
            else if (own.Get_ControLeftX() > 0.8 || Input.GetKey(KeyCode.D))
            {
                if (rigidbody.velocity.magnitude <= player_max_speed)
                {
                    //右に傾いている
                    rigidbody.AddForce(player_speed, 0, 0);
                }
            }

            if(own.Get_ControLeftX() >= -0.8 && own.Get_ControLeftX() < -0.4)
            {
                if (rigidbody.velocity.magnitude <= player_max_speed_half)
                {
                    rigidbody.AddForce(-player_speed, 0, 0);
                }
            }
            else if (own.Get_ControLeftX() <= 0.8 && own.Get_ControLeftX() > 0.4)
            {
                if (rigidbody.velocity.magnitude <= player_max_speed_half)
                {
                    rigidbody.AddForce(player_speed, 0, 0);
                }
            }


            //空中判定
            if (GoldFish.Get_OtherPlayer() == false)
            {
                if ((Rarm.Get_Cling() == true) || (Rleg.Get_Cling() == true) || (Larm.Get_Cling() == true) || (Lleg.Get_Cling() == true) || (top.Get_Cling() == true))
                {

                    rigidbody.angularVelocity = Vector3.zero;

                }
            }
            
            
            //徒歩移動
        }

        if (GoldFish.Get_OtherPlayer() == true)
        {
            if (Input.GetButtonDown(Button_RStick) || Input.GetButtonDown(Button_B))
            {
                JumpFlg = true;
                Jump_FrameCnt = 0;
            }
        }

        if (JumpFlg)
        {
            // 強制移動
            this.transform.position += new Vector3(0, jump_power, 0);
            Jump_FrameCnt++;
        }
        if(Jump_FrameCnt >= 30)
        {
            JumpFlg = false;
        }



        //if (own.Get_Kinema() == true)
        //{
        //    if (Input.GetButtonDown(Button_B))
        //    {
        //        if (own.Get_RL_flg == true)
        //        {
        //            this.gameObject.transform.position -= new Vector3(execute_wall, execute_wall, 0.0f);
        //        }
        //        if (own.Get_RL_flg == false)
        //        {
        //            this.gameObject.transform.position += new Vector3(execute_wall, execute_wall, 0.0f);
        //        }
        //    }
        //}

        //top用-------------------------------------------------------------------------------------------------------
        if (own.Get_Kinema() == true && top.Get_Cling() ==true)
        {
            top_trans = true;
        }
        if (top_trans == true)
        {
            if (own.Get_Kinema() == false)
            {
                top_trans = false;
            }
        }
        if (top.Get_Fixation() <=0)
        {
            top_trans = false;
        }


        if (top_trans == true)
        {
            if (top_shrink.Get_PareTrans == true)
            {
                distance = (this.rigidbody.position + top_shrink.transform.position) / Distance_division;
                rigidbody.position = Vector3.MoveTowards(this.rigidbody.position, distance, Time.deltaTime * FrameSpeed);
            }
        }
        //------------------------------------------------------------------------------------------------------------

        //Rarm用-------------------------------------------------------------------------------------------------------
        if (own.Get_Kinema() == true && Rarm.Get_Cling() == true)
        {
            Rarm_trans = true;
        }
        if(Rarm_trans == true)
        {
            if(own.Get_Kinema() ==false)
            {
                Rarm_trans = false;
            }
        }
        if (Rarm.Get_Fixation() <= 0)
        {
            Rarm_trans = false;
        }


        if (Rarm_trans == true)
        {
            if (Rarm_shrink.Get_PareTrans == true)
            {
                distance = (this.rigidbody.position + Rarm_shrink.transform.position) / Distance_division;
                rigidbody.position = Vector3.MoveTowards(this.rigidbody.position, distance, Time.deltaTime * FrameSpeed);
            }
        }
        //------------------------------------------------------------------------------------------------------------

        //Rleg用-------------------------------------------------------------------------------------------------------
        if (own.Get_Kinema() == true && Rleg.Get_Cling() == true)
        {
            Rleg_trans = true;
        }
        if (Rleg_trans == true)
        {
            if (own.Get_Kinema() == false)
            {
                Rleg_trans = false;
            }
        }
        if (Rleg.Get_Fixation() <= 0)
        {
            Rleg_trans = false;
        }


        if (Rleg_trans == true)
        {
            if (Rleg_shrink.Get_PareTrans == true)
            {
                distance = (this.rigidbody.position + Rleg_shrink.transform.position) / Distance_division;
                rigidbody.position = Vector3.MoveTowards(this.rigidbody.position, distance, Time.deltaTime * FrameSpeed);
            }
        }
        //------------------------------------------------------------------------------------------------------------

        //Larm用-------------------------------------------------------------------------------------------------------
        if (own.Get_Kinema() == true && Larm.Get_Cling() == true)
        {
            Larm_trans = true;
        }
        if (Larm_trans == true)
        {
            if (own.Get_Kinema() == false)
            {
                Larm_trans = false;
            }
        }
        if (Larm.Get_Fixation() <= 0 )
        {
            Larm_trans = false;
        }


        if (Larm_trans == true)
        {
            if (Larm_shrink.Get_PareTrans == true)
            {
                distance = (this.rigidbody.position + Larm_shrink.transform.position) / Distance_division;
                rigidbody.position = Vector3.MoveTowards(this.rigidbody.position, distance, Time.deltaTime * FrameSpeed);
            }
        }
        //------------------------------------------------------------------------------------------------------------

        //Lleg用-------------------------------------------------------------------------------------------------------
        if (own.Get_Kinema() == true && Lleg.Get_Cling() == true)
        {
            Lleg_trans = true;
        }
        if (Lleg_trans == true)
        {
            if (own.Get_Kinema() == false)
            {
                Lleg_trans = false;
            }
        }
        if (Lleg.Get_Fixation() <= 0)
        {
            Lleg_trans = false;
        }

       　
        if (Lleg_trans == true)
        {
            if (Lleg_shrink.Get_PareTrans == true)
            {
                distance = (this.rigidbody.position + Lleg_shrink.transform.position) / 2;
                rigidbody.position = Vector3.MoveTowards(this.rigidbody.position, distance, Time.deltaTime * FrameSpeed);
            }
        }
        //------------------------------------------------------------------------------------------------------------


        //加速度取
        //Debug.Log(rigidbody.velocity);
        //Debug.Log(rigidbody.velocity.magnitude);
    }
}

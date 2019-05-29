using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public sharp_top top;         //プレイヤー情報取得
    public sharp_Rarm Rarm;       //プレイヤー情報取得
    public sharp_Larm Larm;       //プレイヤー情報取得
    public sharp_Rleg Rleg;       //プレイヤー情報取得
    public sharp_Lleg Lleg;       //プレイヤー情報取得
    public Trace GoldFish;
    public Status status;
    private bool bCoinCol;
    private float PlayerHP;
    private float scoreCoin;
    public float PRotSpeed;
    public string RightStickX;
    public string RightStickY;
    public string LeftStickX;
    public string LeftStickY;


    //
    private int rotA;
    private int rotB;
    //

    SpringJoint SpJoint;
    bool spring_flg;
    private player own;

    Vector3 hitPos;//collisionの場所

    Vector3 rigid_rotate;
    float RigidZ;
    //rigid_rotateは左回り（反時計回り）に360°回転
    //一周してもマイナス角にはならない
    //+-36°の72°ずつで計算

    int center_rotate;      //プレイヤの回転角
    float h;               //コントローラ取得
    float v;               //コントローラ取得
    float j;               //コントローラ取得
    float b;               //コントローラ取得
    double kinema_angle;        //刺さった状態での回転角
    public bool floor_flg;      //床と判定
    bool kinema_RL_flg;         //刺さった後右回転か左回転か、falseが左(左右)
    bool kinema_UpDown_flg;     //刺さった後右回転か左回転か、falseが左(上下)
    //public sponge sponge;
    public bool kinematic;  //壁固定用
    new Rigidbody rigidbody;//物理エンジン取得
    Vector3 PlayerAcc;      //加速度

    bool air;               //空中判定用

    GameObject wall;
    Vector3 wall_pos;

    public GameObject SoundManager;
    private Audio m_audio;
    private bool SoundOn;
    private bool CeilingOn;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Balloon";
        rigidbody = GetComponent<Rigidbody>();
        FadeManager.FadeIn();

        center_rotate = 0;
        rigid_rotate = new Vector3(0, 0, 0);
        PlayerHP = status.Get_PLAYER_HP;

        h = 0;
        v = 0;
        floor_flg = false;
        kinematic = false;
        // kinema_angle = 0;
        kinema_RL_flg = false;

        air = false;

        //bCoinCol = big_Coin.GetComponent<Big_Coin>();

        m_audio = SoundManager.GetComponent<Audio>();
        SoundOn = false;

        rigidbody.useGravity = true;
        CeilingOn = false;
    }

    // Update is called once per frame
    void Update()
    {
            rigid_rotate = transform.eulerAngles;
            RigidZ = rigid_rotate.z;
     
        //Debug.Log(playHP);
        //topが上

        //center_rotate
        //0~4 フロア上
        //5~14 空上
        
            if ((RigidZ >= 0 && RigidZ < 36) || (RigidZ >= 324 && RigidZ < 360))
            {
                center_rotate = 0;
            }
            //topが左
            if (RigidZ >= 36 && RigidZ < 108)
            {
                center_rotate = 1;
            }
            //topが左下
            if (RigidZ >= 108 && RigidZ < 180)
            {
                center_rotate = 2;
            }
            //topが右下
            if (RigidZ >= 180 && RigidZ < 252)
            {
                center_rotate = 3;
            }
            //topが右
            if (RigidZ >= 252 && RigidZ < 324)
            {
                center_rotate = 4;
            }

        



        //コントローラースティック取得
        h = Input.GetAxisRaw(RightStickX);
        v = Input.GetAxisRaw(RightStickY);
        j = Input.GetAxisRaw(LeftStickX);
        b = Input.GetAxisRaw(LeftStickY);
        //Debug.Log("x:" + h + "y:" + v);
        //Debug.Log(kinematic);
        //Debug.Log(kinematic);

        if ((Rarm.Get_Cling() == false) && (Rleg.Get_Cling() == false) && (Larm.Get_Cling() == false) && (Lleg.Get_Cling() == false) && (top.Get_Cling() == false))
        {
            //rigidbody.isKinematic = false;
        }

        //kinematicのon,off
        if (kinematic == true)
        {
            //if ((Rarm.Get_Cling() == true) || (Rleg.Get_Cling() == true) || (Larm.Get_Cling() == true) || (Lleg.Get_Cling() == true) || (top.Get_Cling() == true))

            if (!Input.GetButton("PS4 R1"))
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
            }
                //rigidbody.useGravity = false;
                //rigidbody.isKinematic = true;




                //引力
                //distance = Vector3.Distance(targetPos, transform.position);
                //PlayAngle = Target.transform.position - transform.position;
                //rigidbody.AddForce(PlayAngle.normalized * (gravity / Mathf.Pow(distance, 2)));

            /* 回転上下決定用 */
            // 左右
            if (transform.position.x > hitPos.x)
            {
                kinema_RL_flg = false;
            }
            if (transform.position.x < hitPos.x)
            {
                kinema_RL_flg = true;
            }
            // 上下
            if (transform.position.y > hitPos.y)
            {
                kinema_UpDown_flg = false;
            }
            if (transform.position.y < hitPos.y)
            {
                kinema_UpDown_flg = true;
            }
            /* -------------------------- */
        }
        else
        {
            //rigidbody.isKinematic = false;
            //rigidbody.useGravity = true;
        }

        if (kinematic)
        {
            if (kinema_RL_flg)
            {
                if (j >= -0.5 && j <= 0.5 && b == -1)
                {
                    transform.RotateAround(hitPos, Vector3.forward,  -PRotSpeed);   // 右回転
                }
                if (j >= -0.5 && j <= 0.5 && b == 1) 
                {
                    transform.RotateAround(hitPos, Vector3.forward, PRotSpeed);     // 左回転
                }
                //transform.RotateAround(hitPos, Vector3.forward, -(float)kinema_angle);
            }
            if (!kinema_RL_flg)
            {
                if (j >= -0.5 && j <= 0.5 && b == -1)
                {
                    transform.RotateAround(hitPos, Vector3.forward, PRotSpeed);  // 右回転
                }
                if (j >= -0.5 && j <= 0.5 && b == 1)
                {
                    transform.RotateAround(hitPos, Vector3.forward, -PRotSpeed); // 左回転
                }

                //transform.RotateAround(hitPos, Vector3.forward, -(float)kinema_angle);
            }

            if (!kinema_UpDown_flg) // 当たっているところが自分より高い
            {
                if (b >= -0.5 && b <= 0.5 && j == -1)
                {
                    transform.RotateAround(hitPos, Vector3.forward, PRotSpeed);  // 右回転
                }
                if (b >= -0.5 && b <= 0.5 && j == 1)
                {
                    transform.RotateAround(hitPos, Vector3.forward, -PRotSpeed); // 左回転
                }

                //transform.RotateAround(hitPos, Vector3.forward, -(float)kinema_angle);
            }

            if (!kinematic)
            {
                if (kinema_UpDown_flg) // 当たってるところが自分より低い
                {
                    if (b >= -0.5 && b <= 0.5 && j == -1)
                    {
                        transform.RotateAround(hitPos, Vector3.forward, -PRotSpeed);  // 右回転
                    }
                    if (b >= -0.5 && b <= 0.5 && j == 1)
                    {
                        transform.RotateAround(hitPos, Vector3.forward, PRotSpeed); // 左回転
                    }
                }
            }
        }

        // 尖ったら
        if (top.Get_Cling())
        {
            // Soundまだついてなかったら
            if (!SoundOn)
            {
                m_audio.PlaySound(2);   // SE_伸ばす
                SoundOn = true;
            }
        }
        else if (Rarm.Get_Cling())
        {
            if (!SoundOn)
            {
                m_audio.PlaySound(2);   // SE_伸ばす
                SoundOn = true;
            }
        }
        else if (Rleg.Get_Cling())
        {
            if (!SoundOn)
            {
                m_audio.PlaySound(2);   // SE_伸ばす
                SoundOn = true;
            }
        }
        else if(Larm.Get_Cling()){
            if (!SoundOn)
            {
                m_audio.PlaySound(2);   // SE_伸ばす
                SoundOn = true;
            }
        }
        else if (Lleg.Get_Cling())
        {
            if (!SoundOn)
            {
                m_audio.PlaySound(2);   // SE_伸ばす
                SoundOn = true;
            }
        }
        else if (!top.Get_Cling() || !Rarm.Get_Cling() || !Rleg.Get_Cling() || !Larm.Get_Cling() || !Lleg.Get_Cling())
        {
            SoundOn = false;
        }

        
    }





    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.name == "floor")
        {
            floor_flg = true;
        }
        if (collision.gameObject.tag == "Wall")
        {
            kinematic = true;


            foreach (ContactPoint point in collision.contacts)
            {
                hitPos = point.point;
                //Debug.Log(hitPos);
                //transform.LookAt(hitPos);
            }
        }

        if (collision.gameObject.tag == "Ceiling")
        {
            kinematic = true;
            CeilingOn = true;
            if (CeilingOn)
            {
                if (top.Get_Cling() || top.Get_Fixation() <= 0 )
                {
                    Physics.gravity = new Vector3(0, 0, 0);
                }
                foreach (ContactPoint point in collision.contacts)
                {
                    hitPos = point.point;
                }
            }
        }
    }

    

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "floor")   // 床、使っていない。
        {
            floor_flg = false;
        }

        if (collision.gameObject.tag == "Wall")    // 壁
        {
            kinematic = false;
            //kinema_angle = 0;
        }

        if (collision.gameObject.tag == "Ceiling")  // 天井
        {
            kinematic = false;
            CeilingOn = false;
            Physics.gravity = new Vector3(0, (float)-9.81, 0);
        }

        
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "Coin")
        {
            scoreCoin += status.Get_ScoreCoin;
            m_audio.PlaySound(0);   // コイン(小)
        }
        if(collider.gameObject.tag == "BigCoin")
        {
            scoreCoin += status.Get_ScoreBigCoin;
            m_audio.PlaySound(1);   // コイン(大)
        }
        
    }

    public int Get_rotate()
    {
        return center_rotate;
    }

    public double Get_ControX()
    {
        return h;
    }
    public double Get_ControY()
    {
        return v;
    }

    public double Get_ControLeftX()
    {
        return j;
    }
    public double Get_ControLeftY()
    {
        return b;
    }


    public bool Get_Walk()
    {
        return floor_flg;
    }


    public bool Get_Kinema()
    {
        return kinematic;
    }

    public float Get_PlayerHP
    {
        get { return PlayerHP; }
    }

    public float Get_Coins
    {
        get { return scoreCoin; }
    }

    public bool Get_RL_flg { get { return kinema_RL_flg; } }

}



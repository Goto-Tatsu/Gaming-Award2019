//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class player : MonoBehaviour
//{
//    public sharp_top top;       //プレイヤー情報取得
//    public sharp_Rarm Rarm;       //プレイヤー情報取得
//    public sharp_Larm Larm;       //プレイヤー情報取得
//    public sharp_Rleg Rleg;       //プレイヤー情報取得
//    public sharp_Lleg Lleg;       //プレイヤー情報取得

//    Vector3 hitPos;//collisionの場所

//    Vector3 rigid_rotate;
//    //rigid_rotateは左回り（反時計回り）に360°回転
//    //一周してもマイナス角にはならない
//    //+-36°の72°ずつで計算
//    Vector3 rigid_rotate_Stop;
//    //12角で判定とる
//    //+-15°の30°で計算

//    int center_rotate; //プレイヤの回転角
//    int stop_rotate;   //回転を止める角
//    double h;
//    double v;
//    double j;
//    double b;
//    double kinema_angle;//刺さった状態での回転角
//    public bool floor_flg;//床と判定
//    bool kinema_RL_flg;//刺さった後右回転か左か、falseが左
//    //public sponge sponge;
//    public bool kinematic;//壁固定用
//    new Rigidbody rigidbody;
//    // Start is called before the first frame update
//    void Start()
//    {
//        rigidbody = GetComponent<Rigidbody>();
//        FadeManager.FadeIn();

//        center_rotate = 0;
//        stop_rotate = 0;
//        rigid_rotate = new Vector3(0, 0, 0);
//        rigid_rotate_Stop = new Vector3(0, 0, 0);

//        h = 0;
//        v = 0;
//        floor_flg = false;
//        kinematic = false;
//        kinema_angle = 0;
//        kinema_RL_flg = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        rigid_rotate = transform.eulerAngles;

//        //topが上
//        if ((rigid_rotate.z >= 0 && rigid_rotate.z < 36) || (rigid_rotate.z >= 324 && rigid_rotate.z < 360))
//        {
//            center_rotate = 0;
//        }
//        //topが左
//        if (rigid_rotate.z >= 36 && rigid_rotate.z < 108)
//        {
//            center_rotate = 1;
//        }
//        //topが左下
//        if (rigid_rotate.z >= 108 && rigid_rotate.z < 180)
//        {
//            center_rotate = 2;
//        }
//        //topが右下
//        if (rigid_rotate.z >= 180 && rigid_rotate.z < 252)
//        {
//            center_rotate = 3;
//        }
//        //topが右
//        if (rigid_rotate.z >= 252 && rigid_rotate.z < 324)
//        {
//            center_rotate = 4;
//        }

//        rigid_rotate_Stop = transform.eulerAngles;  //オイラー角
//        //左回転で30°ずつ移動
//        if (rigid_rotate_Stop.z >= 0 && rigid_rotate_Stop.z < 30)
//        {
//            stop_rotate = 1;
//        }
//        if (rigid_rotate_Stop.z >= 30 && rigid_rotate_Stop.z < 60)
//        {
//            stop_rotate = 2;
//        }
//        if (rigid_rotate_Stop.z >= 60 && rigid_rotate_Stop.z < 90)
//        {
//            stop_rotate = 3;
//        }
//        if (rigid_rotate_Stop.z >= 90 && rigid_rotate_Stop.z < 120)
//        {
//            stop_rotate = 4;
//        }
//        if (rigid_rotate_Stop.z >= 120 && rigid_rotate_Stop.z < 150)
//        {
//            stop_rotate = 5;
//        }
//        if (rigid_rotate_Stop.z >= 150 && rigid_rotate_Stop.z < 180)
//        {
//            stop_rotate = 6;
//        }
//        if (rigid_rotate_Stop.z >= 180 && rigid_rotate_Stop.z < 210)
//        {
//            stop_rotate = 7;
//        }
//        if (rigid_rotate_Stop.z >= 210 && rigid_rotate_Stop.z < 240)
//        {
//            stop_rotate = 8;
//        }
//        if (rigid_rotate_Stop.z >= 240 && rigid_rotate_Stop.z < 270)
//        {
//            stop_rotate = 9;
//        }
//        if (rigid_rotate_Stop.z >= 270 && rigid_rotate_Stop.z < 300)
//        {
//            stop_rotate = 10;
//        }
//        if (rigid_rotate_Stop.z >= 300 && rigid_rotate_Stop.z < 330)
//        {
//            stop_rotate = 11;
//        }
//        if (rigid_rotate_Stop.z >= 330 && rigid_rotate_Stop.z < 360)
//        {
//            stop_rotate = 12;
//        }


//        //コントローラースティック取得
//        h = Input.GetAxisRaw("PS4RightStickX");
//        v = Input.GetAxisRaw("PS4RightStickY");
//        j = Input.GetAxisRaw("PS4LeftStickX");
//        b = Input.GetAxisRaw("PS4LeftStickY");
//        Debug.Log(kinematic);


//        if (kinematic == false)
//        {
//            if (j < -0.5)
//            {
//                //左に傾いている
//                rigidbody.position -= new Vector3(0.3f, 0.0f, 0.0f);
//                // rigidbody.angularVelocity += new Vector3(0, 0, (float)0.5);
//            }
//            else if (0.5 < j)
//            {
//                //右に傾いている
//                rigidbody.position += new Vector3(0.3f, 0.0f, 0.0f);
//                // rigidbody.angularVelocity += new Vector3(0, 0, (float)-0.5);
//            }
//        }

//        //kinematicのon,off
//        if (kinematic == true)
//        {
//            rigidbody.isKinematic = true;
//            //rigidbody.useGravity = false;

//            if (transform.position.x > hitPos.x)
//            {
//                kinema_RL_flg = false;
//            }
//            if (transform.position.x < hitPos.x)
//            {
//                kinema_RL_flg = true;
//            }
//        }
//        else
//        {
//            rigidbody.isKinematic = false;
//            //rigidbody.useGravity = true;
//        }



//        if (kinematic == true)
//        {
//            //if (kinema_RL_flg == true)
//            {
//                if (j >= -0.5 && j <= 0.5 && b == -1)
//                {
//                    kinema_angle += 5.0;
//                }
//                if (j >= -0.5 && j <= 0.5 && b == 1)
//                {
//                    kinema_angle -= 5.0;
//                }

//                transform.RotateAround(hitPos, Vector3.forward, -(float)kinema_angle);
//            }
//            if (kinema_RL_flg == false)
//            {
//                if (j >= -0.5 && j <= 0.5 && b == -1)
//                {
//                    kinema_angle -= 5.0;
//                }
//                if (j >= -0.5 && j <= 0.5 && b == 1)
//                {
//                    kinema_angle += 5.0;
//                }

//                transform.RotateAround(hitPos, Vector3.forward, -(float)kinema_angle);
//            }
//        }


//        if (transform.position.x <= -50)
//        {
//            FadeManager.FadeOut("End");
//        }
//    }

//    void OnCollisionStay(Collision collision)
//    {

//        if (collision.gameObject.name == "floor")
//        {
//            floor_flg = true;
//        }
//        if (collision.gameObject.name == "Adhesion_block" || collision.gameObject.name == "Adhesion_block2")
//        {
//            kinematic = true;
//        }


//        foreach (ContactPoint point in collision.contacts)
//        {
//            hitPos = point.point;
//            //Debug.Log(hitPos);
//            //transform.LookAt(hitPos);
//        }
//    }

//    void OnCollisionExit(Collision collision)
//    {
//        if (collision.gameObject.name == "floor")
//        {
//            floor_flg = false;
//        }

//        if (collision.gameObject.name == "Adhesion_block" || collision.gameObject.name == "Adhesion_block2")
//        {
//            kinematic = false;
//            kinema_angle = 0;
//        }
//    }


//    void OnControllerColliderHit(ControllerColliderHit col)
//    {
//        if (col.gameObject.layer == LayerMask.NameToLayer("block"))
//        {
//            col.rigidbody.AddForce(-col.normal * 2000f);
//        }
//    }


//    public int Get_rotate()
//    {
//        return center_rotate;
//    }

//    public int Get_rotate_stop()
//    {
//        return stop_rotate;
//    }

//    public double Get_ControX()
//    {
//        return h;
//    }

//    public double Get_ControY()
//    {
//        return v;
//    }

//    public double Get_ControLeftX()
//    {
//        return j;
//    }

//    public double Get_ControLeftY()
//    {
//        return b;
//    }

//    public bool Get_Walk()
//    {
//        return floor_flg;
//    }

//    public bool Get_Kinema()
//    {
//        return kinematic;
//    }
//}

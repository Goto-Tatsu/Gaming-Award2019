using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharp_Larm : MonoBehaviour
{
    double Fixat = 0;    //伸び計算用
    double walk_speed;          //徒歩速

    public player player;       //プレイヤー情報取得
    bool Cling;      //刺さり透過用
    int Rotate;//trueなら左,falseなら右
    public bool Stab;       //引っ付き用
    public sharp_Larm_shrink Larm_shrik;


    new Rigidbody rigidbody;    //物理エンジン

    public float max_range;

    // Start is called before the first frame update
    void Start()
    {
        Fixat = 0;
        walk_speed = 0.08;

        rigidbody = GetComponent<Rigidbody>();

        Stab = false;
        Rotate = 0;
        Cling = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.Get_rotate() == 0)
        {
            //Fixation(0);
            Fixation_Controller(1);
        }
        if (player.Get_rotate() == 1)
        {
            //Fixation(1);
            Fixation_Controller(2);
        }
        if (player.Get_rotate() == 2)
        {
            //Fixation(2);
            Fixation_Controller(3);
        }
        if (player.Get_rotate() == 3)
        {
            //Fixation(3);
            Fixation_Controller(4);
        }
        if (player.Get_rotate() == 4)
        {
            //Fixation(4);
            Fixation_Controller(0);
        }

        transform.localScale = new Vector3(1, 1 + (float)Fixat, 1);


        //if (Cling == true)
        //{
        //    if (Larm_shrik.Get_Shrink == false)
        //    {
        //        Fixat = 0;
        //    }
        //}

        //sharpが伸びているかどうかの判定
        //trueなら伸びてるfalseは通常
        if (Fixat >= 1.0)
        {
            Cling = true;
        }
        if (Fixat < 1.0)
        {
            Cling = false;
        }
        if (!(player.Get_Kinema()))
        {
            Rotate = 0;
        }



        //Debug.Log(gameObject.layer);
    }




    void Fixation(int index)
    {
        //index
        //0 上
        //1 左
        //2 左下
        //3 右下
        //4 右
        if (index == 0)
        {

            //キーボード
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Fixat < 1.0)
                {
                    Fixat += 0.2;
                }
            }
            if (!Input.GetKey(KeyCode.UpArrow))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= 0.2;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }
        }
        if (index == 1)
        {

            //キーボード
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Fixat < 1.0)
                {
                    Fixat += 0.2;
                }
            }
            if (!Input.GetKey(KeyCode.LeftArrow))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= 0.2;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }
        }
        if (index == 2)
        {

            //キーボード
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Fixat < 1.0)
                {
                    Fixat += 0.2;
                }
            }
            if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.D))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= 0.2;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }

            Walk_ToRight();
        }
        if (index == 3)
        {

            //キーボード
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Fixat < 1.0)
                {
                    Fixat += 0.2;
                }
            }
            if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.A))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= 0.2;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }

            Walk_ToLeft();
        }
        if (index == 4)
        {
            //キーボード
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Fixat < 1.0)
                {
                    Fixat += 0.2;
                }
            }
            if (!Input.GetKey(KeyCode.RightArrow))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= 0.2;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }
        }
    }

    void Fixation_Controller(int index)
    {
        //index
        //0 上
        //1 左
        //2 左下
        //3 右下
        //4 右

        if (index == 0)
        {
            //コントーローラ
            if (player.Get_ControX() > -0.5 && player.Get_ControX() < 0.5 && player.Get_ControY() == 1)
            {
                if (Fixat < max_range)
                {
                    Fixat += 0.5;
                }
            }

            if (!(player.Get_ControX() > -0.5 && player.Get_ControX() < 0.5 && player.Get_ControY() == 1))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= 0.2;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }

        }


        if (index == 1)
        {
            //コントーローラ
            if (player.Get_ControX() <= -0.5 && player.Get_ControX() >= -1 && player.Get_ControY() >= -0.4)
            {
                if (Fixat < max_range)
                {
                    Fixat += 0.5;
                }
            }

            if (!(player.Get_ControX() <= -0.5 && player.Get_ControX() >= -1 && player.Get_ControY() >= -0.4))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= 0.2;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }

            Rotate = 1;
        }
        if (index == 2)
        {
                if (player.Get_ControX() <= -0.2 && player.Get_ControX() > -1 && player.Get_ControY() < -0.4)
                {
                    if (Fixat < max_range)
                    {
                        Fixat += 0.5;
                    }
                }

                if (!(player.Get_ControX() <= -0.2 && player.Get_ControX() > -1 && player.Get_ControY() < -0.4))
                {
                    if (Fixat > 0.0)
                    {
                        Fixat -= 0.2;
                    }

                    if (Fixat < 0)
                    {
                        Fixat = 0;
                    }
                }


                Rotate = 1;

            //Jump();

        }
        if (index == 3)
        {
                //コントーローラ
                if (player.Get_ControX() >= 0.2 && player.Get_ControX() < 1 && player.Get_ControY() <= -0.4)
                {
                    if (Fixat < max_range)
                    {
                        Fixat += 0.5;
                    }
                }

                if (!(player.Get_ControX() >= 0.2 && player.Get_ControX() < 1 && player.Get_ControY() <= -0.4))
                {
                    if (Fixat > 0.0)
                    {
                        Fixat -= 0.2;
                    }

                    if (Fixat < 0)
                    {
                        Fixat = 0;
                    }
                }

                Rotate = 2;

            //Jump();

        }
        if (index == 4)
        {
            //コントーローラ
            if (player.Get_ControX() >= 0.5 && player.Get_ControX() <= 1 && player.Get_ControY() >= -0.4)
            {
                if (Fixat < max_range)
                {
                    Fixat += 0.5;
                }
            }

            if (!(player.Get_ControX() >= 0.5 && player.Get_ControX() <= 1 && player.Get_ControY() >= -0.4))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= 0.2;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }


            Rotate = 2;
        }


    }

    void Walk_ToRight()
    {
        if (player.Get_Walk() == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (Fixat < 1.5)
                {
                    Fixat += walk_speed;
                }
            }
            if (!Input.GetKey(KeyCode.D))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= walk_speed;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }
        }
    }

    void Walk_ToLeft()
    {
        if (player.Get_Walk() == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (Fixat < 1.5)
                {
                    Fixat += walk_speed;
                }
            }
            if (!Input.GetKey(KeyCode.A))
            {
                if (Fixat > 0.0)
                {
                    Fixat -= walk_speed;
                }

                if (Fixat < 0)
                {
                    Fixat = 0;
                }
            }
        }
    }



    public int Get_KinemaLarm()
    {
        return Rotate;
    }

    public double Get_Fixation()
    {
        return Fixat;
    }

    public bool Get_Cling()
    {
        return Cling;
    }


}

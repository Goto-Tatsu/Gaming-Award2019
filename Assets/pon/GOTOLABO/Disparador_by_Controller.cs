using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador_by_Controller : MonoBehaviour
{
    // フックのオブジェクトを設定
    public GameObject gancho;
    private GameObject auxGancho;
    public Gancho_190426 gach;
    float distance;

    // カメラのやつ
    public Camera m_camera;

    // クリックしたとこのやつ
    public Transform dirDoClique;
    private Transform auxDirDoClique;

    // ローカルに収める
    private Vector3 localDoClique;
    private Vector3 posMouse;
    private Quaternion olharParaDir;

    /* --飛ばす方向情報を受け取るためのオブジェクトを管理-- */
    public First first;
    public Second second;
    public Third third;
    public Forth forth;
    public Fifth fifth;

    //rigid_Rotateは左回り（反時計回り）に360°回転
    //一周してもマイナス角にはならない
    //+-36°の72°ずつで計算
    private Vector3 rigid_Rotate;

    int center_Rotate; //プレイヤの回転状態をうけとりをenumのように数値を渡して管理
    double h;     //コントローラ所得
    double v;     //コントローラ所得
    double j;     //コントローラ所得
    double b;     //コントローラ所得

    bool one_click;
    
    /* ---------------------------------------------------- */
    // Start is called before the first frame update
    void Start()
    {
        center_Rotate = 0;
        rigid_Rotate = new Vector3(0, 0, 0);
        h = 0; v = 0;
        one_click = false;
        //jump = trace.Get_OtherPlayer();

        distance = gach.GetTamanhoCorda();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(center_Rotate);
        // 回転している各種処理を管轄している
        // posMouseもなかにいる
        RotateManager();
        //SampleKeyButtonDown();


        // フックの軸が無い状態でマウス処理
        //if (auxGancho == null)
        //{
        //    // マウスクリックしたら
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        // クリックしたところに補助クリック位置を生み出す
        //        auxDirDoClique = Instantiate(dirDoClique, posMouse, Quaternion.identity) as Transform;
        //        // クリックした方向を格納(単位ベクトル)
        //        localDoClique = (auxDirDoClique.transform.position - this.transform.position).normalized;
        //        // localDoCliqueの場所を任意軸として設定
        //        olharParaDir = Quaternion.LookRotation(localDoClique);

        //        // フックを、フックのポジションに、任意軸の向きでGameObjectとして生み出す
        //        auxGancho = Instantiate(gancho, this.transform.position, olharParaDir) as GameObject;
        //        Destroy(auxDirDoClique.gameObject);
        //    }
        //}

        // フックの軸がない状態でコントローラー処理
        if (auxGancho == null)
        {

                double LengthMax = 0.2f;
                // 少しでも右スティックの入力があったら
                if (this.Get_ControlerRightX() <= -LengthMax || this.Get_ControlerRightX() >= LengthMax || this.Get_ControlerRightY() <= -LengthMax || this.Get_ControlerRightY() >= LengthMax)
                {
                    //auxDirDoClique = Instantiate(dirDoClique, posMouse, Quaternion.identity) as Transform;

                    localDoClique = (posMouse - this.transform.position);
                    // localDoCliqueの場所を任意回転軸として設定
                    olharParaDir = Quaternion.LookRotation(localDoClique);

                    // フックを、フックのポジションに、任意回転軸の向きでGameObjectとして生み出す
                    auxGancho = Instantiate(gancho, this.transform.position, olharParaDir) as GameObject;
                    //Destroy(auxDirDoClique.gameObject);
                }
            
        }
    }


    // コーンに拡大方向を教える
    public Vector3 GetLocalDoClique()
    {
        return localDoClique;
    }


    // Rotate管理用関数。
    void RotateManager()
    {
        // コントローラーの値を取得
        h = Input.GetAxisRaw("PS4RightStickX");
        v = Input.GetAxisRaw("PS4RightStickY");
        j = Input.GetAxisRaw("PS4LeftStickX");
        b = Input.GetAxisRaw("PS4LeftStickY");
        

        // 現在のplayerの角度保存
        rigid_Rotate = this.transform.eulerAngles;

        //topが上
        if ((rigid_Rotate.z >= 0 && rigid_Rotate.z < 36) || (rigid_Rotate.z >= 324 && rigid_Rotate.z < 360))
        {
            center_Rotate = 0;
        }
        //topが左
        else if (rigid_Rotate.z >= 36 && rigid_Rotate.z < 108)
        {
            center_Rotate = 1;
        }
        //topが左下
        else if (rigid_Rotate.z >= 108 && rigid_Rotate.z < 180)
        {
            center_Rotate = 2;
        }
        //topが右下
        else if (rigid_Rotate.z >= 180 && rigid_Rotate.z < 252)
        {
            center_Rotate = 3;
        }
        //topが右
        else if (rigid_Rotate.z >= 252 && rigid_Rotate.z < 324)
        {
            center_Rotate = 4;
        }


        if(Get_ControlerRightX() > -0.2 && Get_ControlerRightX() < 0.2 && Get_ControlerRightY() <= 0.2 && Get_ControlerRightY() >= -0.2)
        {
            one_click = false;
        }
        else
        {
            one_click = true;
        }

        PlayerRotationState();

    }

    // 方向確認のためのお試し,のちのち消して(2019/04/25 現在)
    void SampleKeyButtonDown()
    {
        if (Input.GetKey(KeyCode.W)) { posMouse = first.GetBallPos(); }         // 上1
        else if (Input.GetKey(KeyCode.D)) { posMouse = second.GetBallPos(); }   // 右2
        else if (Input.GetKey(KeyCode.X)) { posMouse = third.GetBallPos(); }   // 右下3
        else if (Input.GetKey(KeyCode.Z)) { posMouse = forth.GetBallPos(); }   // 左下4
        else if (Input.GetKey(KeyCode.A)) { posMouse = fifth.GetBallPos(); }   // 左5
    }

    // プレイヤーの各種値を受け渡したい
    public int Get_PlayerRotate() { return center_Rotate; }
    public double Get_ControlerRightX() { return h; }
    public double Get_ControlerRightY() { return v; }
    public double Get_ControlerLeftX() { return j; }
    public double Get_ControlerLeftY() { return b; }


    // playerが知っていればいいもの
    void PlayerRotationState()
    {

            switch (center_Rotate)
            {
                case 0:
                    TopIsFirst();
                    break;

                case 1:
                    TopIsSecond();
                    break;

                case 2:
                    TopIsThird();
                    break;

                case 3:
                    TopIsForth();
                    break;

                case 4:
                    TopIsFifth();
                    break;
            }
        
    }

    // firstが頭の時の処理
    void TopIsFirst()
    {
        if (Get_ControlerRightX() > -0.5 && Get_ControlerRightX() < 0.5 && Get_ControlerRightY() == 1)
        {
            // 1(今の頭
            posMouse = first.GetBallPos();
        }
        else if (Get_ControlerRightX() <= -0.5 && Get_ControlerRightX() >= -1 && Get_ControlerRightY() >= -0.4)
        {
            // 5(今の左
            posMouse = fifth.GetBallPos();
        }
        else if (Get_ControlerRightX() < 0 && Get_ControlerRightX() > -1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 4(今の左下
            posMouse = forth.GetBallPos();
        }
        else if (Get_ControlerRightX() > 0 && Get_ControlerRightX() < 1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 3(今の右下
            posMouse = third.GetBallPos();
        }
        else if (Get_ControlerRightX() >= 0.5 && Get_ControlerRightX() <= 1 && Get_ControlerRightY() >= -0.4)
        {
            // 2(今の右
            posMouse = second.GetBallPos();
        }
    }

    // secondが頭の時の処理
    void TopIsSecond() {

        if (Get_ControlerRightX() > -0.5 && Get_ControlerRightX() < 0.5 && Get_ControlerRightY() == 1)
        {
            // 2(今の頭
            posMouse = second.GetBallPos();
        }
        else if (Get_ControlerRightX() <= -0.5 && Get_ControlerRightX() >= -1 && Get_ControlerRightY() >= -0.4)
        {
            // 1(今の左
            posMouse = first.GetBallPos();
        }
        else if (Get_ControlerRightX() < 0 && Get_ControlerRightX() > -1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 5(今の左下
            posMouse = fifth.GetBallPos();
        }
        else if (Get_ControlerRightX() > 0 && Get_ControlerRightX() < 1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 4(今の右下
            posMouse = forth.GetBallPos();
        }
        else if (Get_ControlerRightX() >= 0.5 && Get_ControlerRightX() <= 1 && Get_ControlerRightY() >= -0.4)
        {
            // 3(今の右
            posMouse = third.GetBallPos();
        }

    }

    // thirdが頭の時の処理
    void TopIsThird() {
        if (Get_ControlerRightX() > -0.5 && Get_ControlerRightX() < 0.5 && Get_ControlerRightY() == 1)
        {
            // 3(今の頭
            posMouse = third.GetBallPos();
        }
        else if (Get_ControlerRightX() <= -0.5 && Get_ControlerRightX() >= -1 && Get_ControlerRightY() >= -0.4)
        {
            //2 (今の左
            posMouse = second.GetBallPos();
        }
        else if (Get_ControlerRightX() < 0 && Get_ControlerRightX() > -1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 1(今の左下
            posMouse = first.GetBallPos();
        }
        else if (Get_ControlerRightX() > 0 && Get_ControlerRightX() < 1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 5(今の右下
            posMouse = fifth.GetBallPos();
        }
        else if (Get_ControlerRightX() >= 0.5 && Get_ControlerRightX() <= 1 && Get_ControlerRightY() >= -0.4)
        {
            // 4(今の右
            posMouse = forth.GetBallPos();
        }
    }

    // forthが頭の時の処理
    void TopIsForth() {
        if (Get_ControlerRightX() > -0.5 && Get_ControlerRightX() < 0.5 && Get_ControlerRightY() == 1)
        {
            // 4(今の頭
            posMouse = forth.GetBallPos();
        }
        else if (Get_ControlerRightX() <= -0.5 && Get_ControlerRightX() >= -1 && Get_ControlerRightY() >= -0.4)
        {
            // 3(今の左
            posMouse = third.GetBallPos();
        }
        else if (Get_ControlerRightX() < 0 && Get_ControlerRightX() > -1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 2(今の左下
            posMouse = second.GetBallPos();
        }
        else if (Get_ControlerRightX() > 0 && Get_ControlerRightX() < 1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 1(今の右下
            posMouse = first.GetBallPos();
        }
        else if (Get_ControlerRightX() >= 0.5 && Get_ControlerRightX() <= 1 && Get_ControlerRightY() >= -0.4)
        {
            // 5(今の右
            posMouse = fifth.GetBallPos();
        }
    }

    // fifthが頭の時の処理
    void TopIsFifth() {
        if (Get_ControlerRightX() > -0.5 && Get_ControlerRightX() < 0.5 && Get_ControlerRightY() == 1)
        {
            // 5(今の頭
            posMouse = fifth.GetBallPos();
        }
        else if (Get_ControlerRightX() <= -0.5 && Get_ControlerRightX() >= -1 && Get_ControlerRightY() >= -0.4)
        {
            // 4(今の左
            posMouse = forth.GetBallPos();
        }
        else if (Get_ControlerRightX() < 0 && Get_ControlerRightX() > -1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 3(今の左下
            posMouse = third.GetBallPos();
        }
        else if (Get_ControlerRightX() > 0 && Get_ControlerRightX() < 1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            // 2(今の右下
            posMouse = second.GetBallPos();
        }
        else if (Get_ControlerRightX() >= 0.5 && Get_ControlerRightX() <= 1 && Get_ControlerRightY() >= -0.4)
        {
            // 1(今の右
            posMouse = first.GetBallPos();
        }
    }

    public bool Get_OneCli { get { return one_click; } }
}

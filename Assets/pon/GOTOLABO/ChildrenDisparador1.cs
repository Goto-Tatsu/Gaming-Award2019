using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenDisparador1 : MonoBehaviour
{
    // フックのオブジェクトを設定
    public GameObject gancho;
    private GameObject auxGancho;

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
    private　Vector3 rigid_Rotate;
   
    int center_Rotate; //プレイヤの回転状態をうけとりをenumのように数値を渡して管理
    double h;     //コントローラ所得
    double v;     //コントローラ所得
    double j;     //コントローラ所得
    double b;     //コントローラ所得
    /* ---------------------------------------------------- */
    // Start is called before the first frame update
    void Start()
    {
        center_Rotate = 0;
        rigid_Rotate = new Vector3(0, 0, 0);
        h = 0; v = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // 回転している各種処理を管轄している
        // posMouseもなかにいる
        RotateManager();
        //SampleKeyButtonDown();

        // 試しに一方方向だけ伸ばしてる
        //posMouse = first.GetBallPos();
        //posMouse = Input.mousePosition;
        //posMouse.z = Vector3.Distance(m_camera.transform.position, this.transform.position);
        //posMouse = m_camera.ScreenToWorldPoint(posMouse);


        // フックの軸が無い状態でマウス処理
        if (auxGancho == null)
        {
             // マウスクリックしたら
            if (Input.GetMouseButtonDown(0))
            {
                 // クリックしたところに補助クリック位置を生み出す
                auxDirDoClique = Instantiate(dirDoClique, posMouse, Quaternion.identity) as Transform;
                 // クリックした方向を格納(単位ベクトル)
                localDoClique = (auxDirDoClique.transform.position - this.transform.position).normalized;
                 // localDoCliqueの場所を任意軸として設定
                olharParaDir = Quaternion.LookRotation(localDoClique);

                 // フックを、フックのポジションに、任意軸の向きでGameObjectとして生み出す
                auxGancho = Instantiate(gancho, this.transform.position, olharParaDir) as GameObject;
                Destroy(auxDirDoClique.gameObject);
            }
        }

        // フックの軸がない状態で
        if (auxGancho == null)
        {
            double LengthMax = 0.2f;
            // 少しでも右スティックの入力があったら
            if (this.Get_ControlerRightX() <= -LengthMax || this.Get_ControlerRightX() >= LengthMax || this.Get_ControlerRightY() <= -LengthMax || this.Get_ControlerRightY() >= LengthMax)
            {
                // クリックしたところに補助クリック位置を生み出す
                auxDirDoClique = Instantiate(dirDoClique, posMouse, Quaternion.identity) as Transform;
                // クリックした方向を格納(単位ベクトル)
                localDoClique = (auxDirDoClique.transform.position - this.transform.position).normalized;
                // localDoCliqueの場所を任意軸として設定
                olharParaDir = Quaternion.LookRotation(localDoClique);

                // フックを、フックのポジションに、任意軸の向きでGameObjectとして生み出す
                auxGancho = Instantiate(gancho, this.transform.position, olharParaDir) as GameObject;
                Destroy(auxDirDoClique.gameObject);
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
            posMouse = first.GetBallPos();
        }
        else if (Get_ControlerRightX() <= -0.5 && Get_ControlerRightX() >= -1 && Get_ControlerRightY() >= -0.4)
        {
            posMouse = fifth.GetBallPos();
        }
        else if (Get_ControlerRightX() < 0 && Get_ControlerRightX() > -1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            posMouse = forth.GetBallPos();
        }
        else if (Get_ControlerRightX() > 0 && Get_ControlerRightX() < 1 && Get_ControlerRightY() >= -1 && Get_ControlerRightY() < 0)
        {
            posMouse = third.GetBallPos();
        }
        else if (Get_ControlerRightX() >= 0.5 && Get_ControlerRightX() <= 1 && Get_ControlerRightY() >= -0.4)
        {
            posMouse = second.GetBallPos();
        }
    }

    // firstが頭の時の処理
    void TopIsSecond() { }

    // firstが頭の時の処理
    void TopIsThird() { }

    // firstが頭の時の処理
    void TopIsForth() { }

    // firstが頭の時の処理
    void TopIsFifth() { }

}
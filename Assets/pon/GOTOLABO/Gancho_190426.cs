using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho_190426 : MonoBehaviour
{

    public float velLancar;     // バネ伸縮の強さ(飛ばす・戻ってくる早さ)
    public float tamanhoCorda;  // ロープサイズ(伸びる距離)
    public float forcaCorda;    // 
    public float peso;          // 

    private GameObject player;
    private Rigidbody corpoRigido;
    private SpringJoint efeitoCorda;

    // プレーヤーとの距離を保管
    private float distanciaDoPlayer;
    private bool atirarCorda;
    public static bool cordaColidiu;

    // プレイヤーのスティック情報を受け取るスクリプト
    double h;     //コントローラ所得
    double v;     //コントローラ所得
    double j;     //コントローラ所得
    double b;     //コントローラ所得

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        corpoRigido = GetComponent<Rigidbody>();
        efeitoCorda = player.GetComponent<SpringJoint>();

        atirarCorda = true;
        cordaColidiu = false;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("PS4RightStickX");
        v = Input.GetAxisRaw("PS4RightStickY");


        distanciaDoPlayer = Vector3.Distance(transform.position, player.transform.position);

        // マウスをクリックすると
        if (Input.GetMouseButtonDown(0))
        {
            atirarCorda = false;
        }

        // コントローラー入力があった場合
        //if (rightX != 0 || rightY != 0)
        //{
        //    atirarCorda = false;
        //}
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            atirarCorda = false;
        }

        if (atirarCorda)
        {
            if (!(h > -0.2 && h < 0.2 && v <= 0.2 && v >= -0.2))
            {
                AtirarGancho();
            }
        }
        else
        {
            if (h > -0.2 && h < 0.2 && v <= 0.2 && v >= -0.2)
            {
                RecolharGancho();
            }
        }

        // LineRenderer
        GetComponent<LineRenderer>().SetPosition(0, player.transform.position);
        GetComponent<LineRenderer>().SetPosition(1, this.transform.position);

    }

    // Plyer意外と当たったとき
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.tag != "Player")
        {
            cordaColidiu = true;
        }
    }

    // フック飛ばす処理
    public void AtirarGancho()
    {
        if (distanciaDoPlayer <= tamanhoCorda)
        {

            if (!cordaColidiu)  // プレイヤー意外とあたっていなければ
            {
                // 設定した距離分飛ばす
                transform.Translate(0.0f, 0.0f, velLancar * Time.deltaTime);
                cordaColidiu = false;
            }
            else
            {
                efeitoCorda.connectedBody = corpoRigido;
                efeitoCorda.spring = forcaCorda;
                efeitoCorda.damper = peso;
            }
        }

        if (distanciaDoPlayer > tamanhoCorda)
        {
            atirarCorda = false;
        }
    }


    // フック戻ってくる処理
    public void RecolharGancho()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, velLancar * Time.deltaTime);

        if (distanciaDoPlayer <= 2)
        {
            Destroy(gameObject);
        }
    }


    // 他スクリプトにdistanciaDoPlayerの値を教える
    public float GetDintanciaDoPlayer()
    {
        return distanciaDoPlayer;
    }


    // 他スクリプトにtamanhoCordaの値を教える
    public float GetTamanhoCorda()
    {
        return tamanhoCorda;
    }

}

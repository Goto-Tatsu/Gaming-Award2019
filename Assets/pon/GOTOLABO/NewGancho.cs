using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGancho : MonoBehaviour
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

        distanciaDoPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            atirarCorda = false;
        }

        if (atirarCorda)
            AtirarGancho();
        else
            RecolharGancho();

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

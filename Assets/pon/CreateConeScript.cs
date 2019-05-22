using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateConeScript : MonoBehaviour
{
    // Needle関係
    public GameObject needle;           // Needleを入れてあげる
    private Transform needleTransform;  // 拡大縮小のやつ

    // Gancho関係
    public Gancho ganchoScript;    // Ganchoスクリプトを入れとく
    private float lengthGnacho;     // 拡大する値はここに保管する
    private bool ganchoOn;          // フック出てる？


    // disparador関係
    public Disparador disparadorScript;
    private Vector3 vecLocalDoClipue;
    private float localDoCliqueX;
    private float localDoCliqueY;
    private float localDoCliqueZ;


    // Start is called before the first frame update
    void Start()
    {

        // フックとプレイヤーの距離を格納、サイズ変数として使用
        lengthGnacho = ganchoScript.GetDintanciaDoPlayer();
        Debug.Log(lengthGnacho);
        // 飛ばす方向を受け取り、伸びる方向として格納
        vecLocalDoClipue = disparadorScript.GetLocalDoClique();
    }

    // Update is called once per frame
    void Update()
    {
        // 拡大
        transform.localScale = new Vector3(1, 1 + lengthGnacho, 1);
    }

    
}

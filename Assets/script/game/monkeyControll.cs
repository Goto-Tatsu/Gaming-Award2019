using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyControll : MonoBehaviour
{
    //Rigidあり
    /*public int StartPosX;        //初期ポジションＸ
    public int StartPosY;        //初期ポジションＹ
    public float width;          //横移動幅
    public float up;             //縦移動幅

    bool flag = false;
    public float interval;
    new Rigidbody rigidbody;


    void Start()
    {
        transform.position = new Vector3(StartPosX, StartPosY, 0.0f);
    }


    void Update()
    {
        if (interval >= 100)
        {
            flag = true;
            interval = 0;
        }
        interval++;
    }


    void FixedUpdate()
    {
        if (flag == true)
        {
            flag = false;
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector3 force = new Vector3(width, up, 0.0f);   // 力を設定
            rb.AddForce(force, ForceMode.Impulse);          // 力を加える
        }
    }*/

    //Rigidなし
    public int StartPosX;        //初期ポジションＸ
    public int StartPosY;        //初期ポジションＹ
    public float Speed_width;    //横移動スピード
    public float Speed_height;   //上移動スピード

    float time;     //計測時間


    private void Start()
    {
        transform.position = new Vector3(StartPosX, StartPosY, 0);
    }

    void Update()
    {
        //transform.position = new Vector3(Speed_width + StartPosX, Mathf.Sin(Speed_height) + StartPosY, 0);

        //if (transform.position.y <= 1)
        //{
        //    transform.position = new Vector3(Speed_width + StartPosX, Mathf.Sin(Speed_height) + StartPosY, 0);
        //}

        //Speed_width += 0.01f;
        //Speed_height += 0.5f;

        
        if(transform.position.y <= 10)
        {
            transform.position += new Vector3(0, 0.1f, 0);
        }
    }


    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("player"))
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2D : MonoBehaviour
{

    public GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する Public 変数

    private Vector3 offset;         //プレイヤーとカメラ間のオフセット距離を格納する Public 変数
    private Vector3 Goal;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        
    }
}

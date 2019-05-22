using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincible : MonoBehaviour
{

    Color color;
    new Renderer renderer;
    private bool EnemyHit;          //敵との当たりフラグ
    private float InvinsibleCount;    //無敵時間
    private float Alpha;
    // Start is called before the first frame update

    private float frameCnt;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        EnemyHit = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHit == true)
        {

            InvinsibleCount++;
            if (InvinsibleCount % 2 == 0)
            {
                Alpha = 1.0f;
            }
            if (InvinsibleCount % 2 == 1)
            {
                Alpha = 0.0f;
            }

            renderer.material.SetColor("_Color", new Color(255, 255, 255, Alpha));
            

            if(InvinsibleCount >= 80.0f)
            {
                EnemyHit = false;
                InvinsibleCount = 0;
            }
        }

        

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHit = true;
            //Debug.Log("Hit");
        }
    }
}

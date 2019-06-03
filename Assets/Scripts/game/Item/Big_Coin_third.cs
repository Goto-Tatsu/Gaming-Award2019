using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Coin_third : MonoBehaviour
{
    public Big_Coin Big_coin;
    private int counter;
    private float high;
    private bool Get_flg;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        high = 0;
        Get_flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Big_coin.Get_CoinEff == false)
        {
            transform.Rotate(new Vector3(0, -4, 0));
        }

        if (Big_coin.Get_CoinEff == true)
        {
            Get_flg = true;
            transform.Rotate(new Vector3(0, -16, 0));
            counter++;
            high++;
            if (counter <= 60)
            {
                if (high < 5.0f)
                {
                    transform.position += new Vector3(0.0f, 0.5f, 0.0f);
                }

            }

            if (counter > 60)
            {
                Destroy(this.transform.gameObject);
                counter = 0;
                high = 0;
            }
        }
    }

    public bool Get_Getflg { get { return Get_flg; } }
}

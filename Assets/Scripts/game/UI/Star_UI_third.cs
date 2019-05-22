using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star_UI_third : MonoBehaviour
{
    public Sprite none;
    public Sprite get;
    public Big_Coin_third BigCoin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BigCoin.Get_Getflg == true)
        {
            this.gameObject.GetComponent<Image>().sprite = get;
        }
    }
}

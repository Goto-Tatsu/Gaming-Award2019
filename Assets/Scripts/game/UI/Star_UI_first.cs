using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star_UI_first : MonoBehaviour
{

    public Sprite none;
    public Sprite get;
    public Big_Coin_first BigCoin;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BigCoin.Get_Getflg == true)
        {
            this.gameObject.GetComponent<Image>().sprite = get;
        }
    }
}

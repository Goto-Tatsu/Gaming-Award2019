using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    //public PlayerMoveController player;
    public player player;
    public Text Cointext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cointext.text = player.Get_Coins.ToString();
    }
}

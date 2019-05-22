using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UItext : MonoBehaviour
{
    public player player;
    //public PlayerMoveController player;
    public Text HPtext;
    // Start is called before the first frame update
    void Start()
    {


        //Debug.Log(player.Get_PlayerHP);
    }

    // Update is called once per frame
    void Update()
    {
       HPtext.text = player.Get_PlayerHP.ToString();
    }
}

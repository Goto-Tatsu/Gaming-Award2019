using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{

    public float Player_HP;
    public float Enemy_HP;
    public int coin_score;
    public int bigCoin_score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float Get_PLAYER_HP
    {
        get { return this.Player_HP; }
    }

    public float Get_ENEMY_HP
    {
        get { return this.Enemy_HP; }
    }

    public int Get_ScoreCoin
    {
        get { return this.coin_score; }
    }

    public int Get_ScoreBigCoin
    {
        get { return this.bigCoin_score; }
    }
}

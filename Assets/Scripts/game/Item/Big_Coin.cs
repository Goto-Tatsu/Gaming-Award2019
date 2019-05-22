using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Coin : MonoBehaviour
{

    private bool effect;
    private bool collisionOff;
    // Start is called before the first frame update
    void Start()
    {
        effect = false;
        collisionOff = false;
        gameObject.tag = "BigCoin";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            effect = true;
            collisionOff = true;
        }
    }

    public bool Get_CoinEff { get { return effect; } }

    public bool Get_CoinCol { get { return collisionOff; } }
}

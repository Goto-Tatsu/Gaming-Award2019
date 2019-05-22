using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetable : MonoBehaviour
{
    public float fMoveY;
    public  float fMoveY_Max, fMoveY_min;
    private float fMovePos;

    private bool bMoving;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // フレーム数が動かしたい文
        if (bMoving == true)
        {
            this.gameObject.transform.Translate(0, fMoveY, 0);
            fMovePos += fMoveY;
            if (fMoveY_Max <= fMovePos) { bMoving = false; }
        }
        else if (bMoving == false)
        {
            this.gameObject.transform.Translate(0, -fMoveY, 0);
            fMovePos -= fMoveY;
            if (fMovePos <= fMoveY_min) { bMoving = true; }
        }
    }
}

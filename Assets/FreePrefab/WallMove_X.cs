using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove_X : MonoBehaviour
{
    public float fMoveX;
    public float fMoveX_Max, fMoveX_min;
    private float fMovePos;

    private bool bMoving;

    // Start is called before the first frame update
    void Start()
    {
        bMoving = true;
        fMovePos = fMoveX;
    }

    void Update()
    {
        // フレーム数が動かしたい文
        if (bMoving == true)
        {
            this.gameObject.transform.Translate(fMoveX, 0, 0);
            fMovePos += fMoveX;
            if (fMoveX_Max <= fMovePos) { bMoving = false; }
        }
        else if (bMoving == false)
        {
            this.gameObject.transform.Translate(-fMoveX, 0, 0);
            fMovePos -= fMoveX;
            if (fMovePos <= fMoveX_min) { bMoving = true; }
        }

    }
}

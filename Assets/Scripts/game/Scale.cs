using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public float ScaleChange;


    private int DownTime;
    private int UpTime;
    private double FrameCount; 
    private bool bFallen;
    private bool bInterval;
    private int Interval;

    private void Start()
    {
        DownTime = 0;
        UpTime = 0;

        bFallen = false;
        bInterval = false;
        Interval = 0;
    }

    private void Update()
    {
        FrameCount++;

        if (!bFallen && !bInterval)
        {
            transform.localScale += new Vector3(0, ScaleChange, 0);
            if(FrameCount >= DownTime)
            {
                bFallen = true;
                FrameCount = 0;
            }
        }

        if (bFallen && !bInterval)
        {
            transform.localScale += new Vector3(0, -ScaleChange, 0);
            if (FrameCount >= UpTime)
            {
                bFallen = false;
                FrameCount = 0;
                bInterval = true;
            }
        }

        if (bInterval)
        {
            if(Interval <= FrameCount)
            {
                bInterval = false;
                FrameCount = 0;
            }
        }

        
    }

}

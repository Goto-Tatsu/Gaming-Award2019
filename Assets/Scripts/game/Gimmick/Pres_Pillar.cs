using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pres_Pillar : MonoBehaviour
{

    public float speed;         //伸び縮みの速さ
    public float interval;      //フラグ切り替えの間隔
    public float fall;          //落ちる距離

    public float Get_Interval { get { return interval; } }

    public float Get_Speed { get { return speed; } }

    public float Get_Fall { get { return fall; } }
}

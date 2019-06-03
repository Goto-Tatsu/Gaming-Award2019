using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlag3 : MonoBehaviour
{
    public player player;
    [SerializeField]
    public static bool bGoal;

    private void Start()
    {
        bGoal = false;
    }


    private void Update()
    {
        if (gameObject.transform.position.x <= player.Get_PlayerPosX())
        {
            bGoal = true;
        }
        else
        {
            bGoal = false;
        }
    }

    public bool Get_Goal() { return bGoal; }
}

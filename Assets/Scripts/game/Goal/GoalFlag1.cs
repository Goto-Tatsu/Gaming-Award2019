using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlag1 : MonoBehaviour
{
    public player player;

    [SerializeField]
    public bool bGoal;

    private void Start()
    {
        bGoal = false;
    }


    private void Update()
    {
        if(gameObject.transform.position.x <= player.Get_PlayerPosX())
        {
            bGoal = true;
        }
    }

    public bool Get_Goal() { return bGoal; }
}
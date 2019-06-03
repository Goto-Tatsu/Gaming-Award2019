using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFlagManeger : MonoBehaviour
{
    public GoalFlag1 flag1;
    public GoalFlag2 flag2;
    public GoalFlag3 flag3;
    public GoalFlag4 flag4;
    public GoalFlag5 flag5;
    public GoalFlag6 flag6;
    public GoalFlagBoss flagBoss;

    // シーンを読み込むたびに
    // 受け取っている各ステージのフラグを読む
    private void Start()
    {
        flag1.Get_Goal();
        flag2.Get_Goal();
        flag3.Get_Goal();
        flag4.Get_Goal();
        flag5.Get_Goal();
        flag6.Get_Goal();
        flagBoss.Get_Goal();
    }

    public bool Get_GoalFlag1() { return flag1.Get_Goal(); }
    public bool Get_GoalFlag2() { return flag2.Get_Goal(); }
    public bool Get_GoalFlag3() { return flag3.Get_Goal(); }
    public bool Get_GoalFlag4() { return flag4.Get_Goal(); }
    public bool Get_GoalFlag5() { return flag5.Get_Goal(); }
    public bool Get_GoalFlag6() { return flag6.Get_Goal(); }
    public bool Get_GoalFlagBoss() { return flagBoss.Get_Goal(); }
}

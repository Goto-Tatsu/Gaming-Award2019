using UnityEngine;
using System.Collections;
using System;

public class CreateNewData : MonoBehaviour
{

    private SaveData saveData;
    [SerializeField]
    private GameObject obj;

    //　スタート時にデータを生成する
    void Start()
    {
        saveData = new SaveData();

        // 初期データをセット
        saveData.SetHp(10);
        saveData.SetMp(20);
        saveData.SetPower(30);
        saveData.SetFlag(true);
        saveData.SetVector(new Vector3(1f, 3f, 6f));
        saveData.SetObj(obj);
    }

    public SaveData GetSaveData()
    {
        return saveData;
    }
}

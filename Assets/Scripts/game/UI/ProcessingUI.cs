using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProcessingUI : MonoBehaviour
{
    //　データ表示テキスト
    [SerializeField]
    private Text dataText;
    //　データを生成し保持しているスクリプト
    private CreateNewData createNewData;
    [SerializeField]
    private InputField hpField;
    [SerializeField]
    private InputField mpField;
    [SerializeField]
    private InputField powerField;
    void Start()
    {
        createNewData = GetComponent<CreateNewData>();
    }
    //　データ表示のテキストを空にする
    public void ResetText()
    {
        dataText.text = "";
    }
    //　現在のオブジェクトの変数のデータを表示する
    public void ShowParameter()
    {
        ResetText();
        dataText.text = createNewData.GetSaveData().GetNormalData();
    }
    //　現在のオブジェクトのJSONデータを表示
    public void ShowJsonData()
    {
        ResetText();
        dataText.text = createNewData.GetSaveData().GetJsonData();
    }
    //　現在のオブジェクトのJSONデータを保存する
    public void SaveData()
    {
        ResetText();
        PlayerPrefs.SetString("PlayerData", createNewData.GetSaveData().GetJsonData());
    }
    public void SetHp()
    {
        createNewData.GetSaveData().SetHp(int.Parse(hpField.text));
    }
    public void SetMp()
    {
        createNewData.GetSaveData().SetMp(int.Parse(mpField.text));
    }
    public void SetPower()
    {
        createNewData.GetSaveData().SetPower(int.Parse(powerField.text));
    }
    //　データをロードしてオブジェクトのフィールドにデータを入れる
    public void LoadFromJsonOverwrite()
    {
        ResetText();
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            var data = PlayerPrefs.GetString("PlayerData");
            JsonUtility.FromJsonOverwrite(data, createNewData.GetSaveData());
            dataText.text = createNewData.GetSaveData().GetJsonData();
        }
    }
    //　データをロードしインスタンスを生成する
    public void CreateData()
    {
        ResetText();
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            var data = PlayerPrefs.GetString("PlayerData");
            SaveData otherSaveData = JsonUtility.FromJson<SaveData>(data);
            dataText.text = otherSaveData.GetJsonData();
        }
    }
    //　データを削除する
    public void DeleteData()
    {
        ResetText();
        PlayerPrefs.DeleteAll();
    }
}

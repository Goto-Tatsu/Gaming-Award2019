using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject player;
    public GameObject OnPanel, OnUnPanel;
    public Pause_Back back;
    private bool pauseGame = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("PS4 Option"))
        {
            pauseGame = !pauseGame;
        }
        
        if (pauseGame == true)
        {
            OnPause();
        }
        else
        {
            OnUnPause();
        }

    }

    public void OnPause()
    {
        OnPanel.SetActive(true);        // PanelMenuをtrueにする
        OnUnPanel.SetActive(false);     // PanelEscをfalseにする
        Time.timeScale = 0;
        pauseGame = true;
        

       // Cursor.lockState = CursorLockMode.None;     // 標準モード
       // Cursor.visible = true;    // カーソル表示
    }

    public void OnUnPause()
    {
        OnPanel.SetActive(false);       // PanelMenuをfalseにする
        OnUnPanel.SetActive(true);      // PanelEscをtrueにする
        Time.timeScale = 1;
        pauseGame = false;
        

       // Cursor.lockState = CursorLockMode.Locked;   // 中央にロック
       // Cursor.visible = false;     // カーソル非表示
    }

    public bool Get_PauseGame { get { return pauseGame; } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgm : MonoBehaviour
{
    public GameObject BgmManager;
    public int BGM_Number;
    private Audio_BGM m_audio;
    private bool bSoundOn;

    // Start is called before the first frame update
    void Start()
    {
        m_audio = BgmManager.GetComponent<Audio_BGM>();
        bSoundOn = false;
    }

    private void Update()
    {
        if (!bSoundOn)
        {
            m_audio.PlayBGM(BGM_Number);
            bSoundOn = true;
        }
    }
}

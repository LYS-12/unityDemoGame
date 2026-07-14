using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{

    private static BKMusic instance;

    private AudioSource audioSource;
    public static BKMusic Instance => instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSource = this.GetComponent<AudioSource>();
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBk);
    }
    /// <summary>
    /// 改变背景音乐大小
    /// </summary>
    /// <param name="value"></param>
    public void ChangeValue(float value)
    {
        audioSource.volume=value;
    }
    /// <summary>
    /// 开关背景音乐
    /// </summary>
    /// <param name="isOpen"></param>
    public void ChangeOpen(bool isOpen)
    {
        //如果开启 就是不静音
        audioSource.mute=!isOpen;
    }
}

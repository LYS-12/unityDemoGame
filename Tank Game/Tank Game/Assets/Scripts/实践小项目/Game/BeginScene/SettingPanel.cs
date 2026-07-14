using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    //声明成员变量 关联控件
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;

    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        //监听对应的事件 处理逻辑
        //处理音乐音量的逻辑
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBkValue(value);
        //处理音乐音效的逻辑
        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);
        //处理音乐开关的逻辑
        togMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBkMusic(value);
        //处理音效开关的逻辑
        togSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBkSound(value);


        btnClose.clickEvent += () =>
        {
            //关闭设置面板
            HideMe();
            //判断当前所在场景
            
            if (SceneManager.GetActiveScene().name=="Begin Scene")
            {

                BeginPanel.Instance.ShowMe();
            }
        };
        HideMe();
    }

    public void UpdatePanelInfo()
    {
        //我们面板上的信息都是根据 音效数据 更新的
        MusicData data = GameDataMgr.Instance.musicData;
        //设置面板
        sliderMusic.nowValue = data.bkValue;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenBk;
        togSound.isSel = data.isOpenSound;

    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}

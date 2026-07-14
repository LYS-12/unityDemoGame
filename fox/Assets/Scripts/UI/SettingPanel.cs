using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public Image bgImage;
    public Slider bgSlider;
    public Slider bkSlider;
    public Button btnExit;
    public override void Init()
    {
        //点击关闭设置面板
        btnExit.onClick.AddListener(() => {
        //隐藏面板
        UIManager.Instance.HidePanel<SettingPanel>();
        //显示面板
        UIManager.Instance.ShowPanel<StartPanel>();

        });



    }
    override public void ShowMe()
    {
        base.ShowMe();
        bgSlider.value = AudioManager.Instance.GetBgVolume();
        bkSlider.value = AudioManager.Instance.GetBkVolume();
    }
    override public void HideMe(UnityAction callBack)
    {
        base.HideMe(callBack);
        AudioManager.Instance.SaveBgVolume(bgSlider.value);
        AudioManager.Instance.SaveBkVolume(bkSlider.value);
    }
}

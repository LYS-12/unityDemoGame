using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartPanel : BasePanel
{
    public Button startBtn;
    public Button settingBtn;

    public override void Init()
    {
        startBtn.onClick.AddListener(()=>{
            UIManager.Instance.HidePanel<StartPanel>();
            UIManager.Instance.ShowPanel<ChoosePanel>();
        });
        settingBtn.onClick.AddListener(() =>{
            UIManager.Instance.HidePanel<StartPanel>();
            UIManager.Instance.ShowPanel<SettingPanel>();
        });

    }
}

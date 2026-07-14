using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPanel : BasePanel
{
    public Button btn;

    public override void Init()
    {
        //给按钮添加回到开始游戏场景的功能
        btn.onClick.AddListener(() => {
            UIManager.Instance.HidePanel<FinalPanel>();
            Loader.Load(Loader.Scene.StartScene);
            UIManager.Instance.ShowPanel<StartPanel>();

        });

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnGoOn;
    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            SceneManager.LoadScene("Begin Scene");
        };
        //继续游戏和叉叉都是关闭面板的逻辑
        btnGoOn.clickEvent += () => {
            HideMe();
        };
        btnClose.clickEvent += () => {
            HideMe();
        };
        HideMe();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {

    }
}

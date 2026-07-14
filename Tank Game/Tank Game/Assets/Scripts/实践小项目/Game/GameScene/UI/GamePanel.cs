using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //获取控件
    public CustomGUILabel labelScore;
    public CustomGUILabel labTime;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;
    public CustomGUITexture texHP;
    //血条
    public float hpw = 350;
    //用于记录玩家的当前分数
    [HideInInspector]
    public int nowScore = 0;
    private int time;

    [HideInInspector]
    public float nowTime= 0;
    // Start is called before the first frame update
    void Start()
    {
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () =>
        {
            //返回游戏界面
            //弹出一个确定退出的按钮
            QuitPanel.Instance.ShowMe();

            Time.timeScale = 0;
        };

    }

    // Update is called once per frame
    void Update()
    {
        //通过帧间隔时间比较准确
        nowTime += Time.deltaTime;

        time = (int)nowTime;
        labTime.content.text = "";
        if (time / 3600 > 0)
        {
            labTime.content.text += time / 3600 + "时";
        }
        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + "分";
        }
        labTime.content.text += time % 60 + "秒";
    }
    /// <summary>
    /// 提供给外部的加分方法
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        nowScore += score;

        labelScore.content.text = nowScore.ToString();
    }
    /// <summary>
    /// 更新血条的方法
    /// </summary>
    /// <param name="maxHP"></param>
    /// <param name="HP"></param>
    public void UpdateHP(int maxHP, int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpw;
    }
}

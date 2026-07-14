using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    //关联Public控件
    public CustomGUIButton btnClose;
    //控件太多

    private List<CustomGUILabel> labName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            //找子对象的子对象PM/
            labName.Add(transform.Find($"Name/labName{i}").GetComponent<CustomGUILabel>());
            labScore.Add(transform.Find($"Score/labScore{i}").GetComponent<CustomGUILabel>());
            labTime.Add(transform.Find($"Time/labTime{i}").GetComponent<CustomGUILabel>());

        }
        //处理事件监听逻辑

        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        //添加测试数据
        //GameDataMgr.Instance.AddRankInfo("张三", 100, 8432);


        HideMe();
    }
    public void UpdatePanelInfo()
    {
        //更新面板信息
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++)
        {
            RankInfo data = list[i];

            labName[i].content.text = data.name;
            labScore[i].content.text = data.score.ToString();
            int time = (int)list[i].time;
            labTime[i].content.text ="";
            if(time /3600 > 0)
            {
                labTime[i].content.text += time / 3600 + "时";
            }
            if (time % 3600 / 60 > 0 || labTime[i].content.text!="")
            {
                labTime[i].content.text += time % 3600 / 60+ "分";
            }
            labTime[i].content.text += time % 60 + "秒";
        }
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
    // Update is called once per frame
    void Update()
    {

    }
}

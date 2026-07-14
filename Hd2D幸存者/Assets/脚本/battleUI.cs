using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class battleUI : MonoBehaviour
{
    public GameObject 技能项目预制体;
    public Transform 技能容器;
    public Transform 玩家技能表;
    public Player player;
    public Transform 菜单;
    public TextMeshProUGUI 生命数字;
    public TextMeshProUGUI 等级文本;
    public Transform 经验条;
    public Image 血条;
    public int 分;
    public int 秒;
    public TextMeshProUGUI 倒计时文本;
    public bool 允许倒计时 = false;
    public float 计时器;
    public GameObject 三选一UI;
    public GameObject 死亡UI;
    public GameObject 标题画面;
    public GameObject 战斗画面;
    public GameObject 胜利UI;
    public GameObject 设置UI;
    public GameObject 操作说明UI;
    public 存档管理 存档管理;

    public 声音管理 声音;
    public Slider SE音量滑条;
    public Slider BGM音量滑条;


    void OnEnable()
    {
        刷新技能();
        开始倒计时();
        声音.播放BGM(声音.战斗bgm);
    }
    public void 刷新技能()//创建技能图标
    {
        if (技能容器.childCount > 0)
        {
            foreach (Transform s in 技能容器)
            {
                Destroy(s.gameObject);
            }
        }
        foreach (Transform playerskill in 玩家技能表)
        {
            GameObject skill = Instantiate(技能项目预制体, 技能容器);
            skill.transform.GetChild(0).GetComponent<Image>().sprite = playerskill.GetComponent<Skillbase>().icon;
            skill.transform.GetChild(1).GetComponent<Image>().sprite = playerskill.GetComponent<Skillbase>().icon;
        }
    }



    public void 开始倒计时()
    {
        分 = 10;
        秒 = 0;
        计时器 = 0;

        允许倒计时 = true;
    }

    public void 打开三选一UI()
    {
        Time.timeScale = 0;
        三选一UI.SetActive(true);
    }

    public void 开始显示死亡UI()
    {
        死亡UI.SetActive(true );
    }

    public void 返回标题画面()
    {
        标题画面.SetActive(true );
        死亡UI.SetActive(false);
        胜利UI.SetActive(false);
        菜单.gameObject.SetActive(false); 
        战斗画面.SetActive(false);
    }




    // Update is called once per frame
    void Update()
    {
        int 索引 = 0;

        if (技能容器.childCount > 0) 
        {
            foreach (Transform skill in 玩家技能表)
            {
                Skillbase s = skill.GetComponent<Skillbase>();
                float 冷却进度比例 = s.CDkey / s.CDtime;
                技能容器.transform.GetChild(索引).GetChild(1).GetComponent<Image>().fillAmount = 冷却进度比例;
                索引++;
                if (索引> 技能容器.childCount)
                {
                    索引 = 0;

                }
            }
        }
        float 生命值比例 = (float)player.shengminh / (float)player.shengmaxh;
        血条.fillAmount =生命值比例;
        float 经验值比例 = (float)player.经验值/ (float)player.最大经验值;
        经验条.localScale = new Vector3(经验值比例, 1, 1);
        等级文本.text = "level：" + player.等级;
        生命数字.text = player.shengminh +"/" +player.shengmaxh;

        if (允许倒计时 == true)
        {
            计时器 += Time.deltaTime;
            if (计时器 >= 1)
            {
                计时器 = 0;
                秒 -= 1;
                if (秒 < 0)
                { 
                    分 -= 1;
                    秒 = 59;
                }

                if (秒 <= 0&&分<=0)
                {
                    游戏胜利();
                }
            }

            if (秒 < 10) 
            {
                倒计时文本.text = 分 + "：0" + 秒;
            }
            else
            {
                倒计时文本.text = 分 + "：" + 秒;
            }

        }

    }

    public void 调整BGM()
    {
        声音.同步显示BGM滑条(BGM音量滑条);
    }
    public void 调整SE()
    {
        声音.同步显示SE滑条(SE音量滑条);
    }

    public void 游戏胜利()
    {
        胜利UI.SetActive(true);
        player.玩家死亡 = true;
        int 天赋奖励 = player.等级 * 10;
        胜利UI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text ="获得天赋：" +天赋奖励;
        player.天赋点 += 天赋奖励;
        player.真实天赋点 += 天赋奖励;
        存档管理.save();
    }
    public void Click_菜单按钮()
    {
        声音.播放ui按钮音效();
        菜单.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Click_继续游戏()
    {
        声音.播放ui按钮音效();
        菜单.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Click_打开设置()
    {
        声音.播放ui按钮音效();
        设置UI.SetActive(true);
        SE音量滑条.value = 声音.SE音量;
        BGM音量滑条.value = 声音.BGM音量;
    }
    public void Click_关闭设置()
    {
        声音.播放ui按钮音效();
        设置UI.SetActive(false);
    }
    public void Click_打开操作说明()
    {
        声音.播放ui按钮音效();
        操作说明UI.SetActive(true);
    }
    public void Click_关闭操作说明()
    {
        声音.播放ui按钮音效();
        操作说明UI.SetActive(false);
    }
    //public void Click_退出游戏()
    //{

    //}
}

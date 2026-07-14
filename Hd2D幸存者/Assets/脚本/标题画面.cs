using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 标题画面 : MonoBehaviour
{
    public Transform 怪物层;
    public GameObject 战斗画面;
    public GameObject 天赋页面;
    public Player 玩家;

    public TextMeshProUGUI 天赋点文本;
    public Transform 生命值加成容器;
    public Transform 攻击力加成容器;
    public 存档管理 存档管理;
    public 声音管理 声音;
    public Slider SE音量滑条;
    public Slider BGM音量滑条;



    private void OnEnable()
    {
        RenderSettings.fogColor = new Color(0.34f, 0.62f, 0.71f);
        RenderSettings.fogDensity = 0.05f;
        Time.timeScale = 1;
        存档管理.load();
        声音.播放BGM(声音.标题画面bgm);
        SE音量滑条.value = 声音.SE音量;
        BGM音量滑条.value = 声音.BGM音量;
    }
    public void Click_开始游戏()
    {
        声音.播放ui按钮音效();
        if (怪物层.childCount > 0)//删除所有怪物
        {
            foreach (Transform monster in 怪物层)
            {
                Destroy(monster.gameObject);
            }
        }
        战斗画面.SetActive(true);
        RenderSettings.fogColor = new Color(0.76f, 0.94f, 1);
        RenderSettings.fogDensity = 0.025f;
        玩家.玩家死亡 = false;
        玩家.transform.position = new Vector3(-2.759f, 10f, 2.890f);
        玩家.同步初始属性();

        玩家.天赋加成();

        gameObject.SetActive(false);
        //调整雾的颜色





    }
    public void 调整BGM()
    {
        声音.同步显示BGM滑条(BGM音量滑条);
    }
    public void 调整SE()
    {
        声音.同步显示SE滑条(SE音量滑条);
    }


    public void Click_开发组()
    {
        声音.播放ui按钮音效();
        Application.OpenURL("https://pd.qq.com/s/9569ypmu0");
    }

    public void 打开天赋()
    {
        声音.播放ui按钮音效();
        天赋页面.SetActive(true);
        刷新天赋界面();
    }

    public void 关闭天赋()
    {
        声音.播放ui按钮音效();
        天赋页面.SetActive(false);
    }
    public void Click_退出游戏()
    {
        声音.播放ui按钮音效();
        Application.Quit();
    }

    public void Click_增加生命值()
    {
        声音.播放ui按钮音效();
        增加天赋(玩家.生命值加成,"生命值");
    }
    public void Click_减少生命值()
    {
        声音.播放ui按钮音效();
        减少天赋(玩家.生命值加成, "生命值");
    }
    public void Click_增加攻击力()
    {
        声音.播放ui按钮音效();
        增加天赋(玩家.攻击力加成, "攻击力");
    }
    public void Click_减少攻击力()
    {
        声音.播放ui按钮音效();
        减少天赋(玩家.攻击力加成, "攻击力");
    }


    public void 减少天赋(int 天赋次数, string 天赋名)
    {
        if (天赋次数 > 0)
        {
            switch (天赋名)
            {
                case "生命值":
                    玩家.生命值加成 -= 1;

                    break;
                case "攻击力":
                    玩家.攻击力加成 -= 1;
                    break;
            }

            玩家.天赋点 += (天赋次数-1) * 10 + 10;
            刷新天赋界面();
        }
    }



    public void Click_重置天赋()
    {
        声音.播放ui按钮音效();
        玩家.天赋点 = 玩家.真实天赋点;
        玩家.生命值加成 = 0;
        玩家.攻击力加成 = 0;
        刷新天赋界面();
    }

    public void 增加天赋(int 天赋次数,string 天赋名)
    {



        int 当前消耗天赋值 =天赋次数 * 10 +10;
        if (玩家.天赋点>= 当前消耗天赋值)
        {


            玩家.天赋点 -=当前消耗天赋值;
            switch (天赋名)
            {
                case "生命值":
                    玩家.生命值加成 += 1;

                    break;
                case "攻击力":
                    玩家.攻击力加成 += 1;
                    break;
            }
            刷新天赋界面();
        }
    }
    public void 刷新天赋界面()
    {
        刷新单个天赋容器(生命值加成容器,玩家.生命值加成,20,"生命值");
        刷新单个天赋容器(攻击力加成容器, 玩家.攻击力加成, 5, "攻击力");
        天赋点文本.text ="天赋点："+  玩家.天赋点.ToString();
    }


    public void 刷新单个天赋容器(Transform 容器, int 天赋次数, int 倍数, string 天赋名)//点了几次天赋的值
    {
        容器.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = 天赋名 + "+" + (倍数 + 天赋次数 * 倍数) + "<color=#FF6C6C>（已加" + 天赋次数 * 20 + "）</color>";
        容器.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "消耗：" + (天赋次数 * 10 +10);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 存档管理 : MonoBehaviour
{
    public Player 玩家;
    public 声音管理 声音;



    public void load() //读取存档
    {
        玩家.天赋点 = ES3.Load<int>("天赋点", 0);
        玩家.真实天赋点 = ES3.Load<int>("真实天赋点", 0);
        玩家.攻击力加成 = ES3.Load<int>("攻击力加成", 0);
        玩家.生命值加成 = ES3.Load<int>("生命值加成", 0);
        声音.SE音量 = ES3.Load<float>("SE音量", 0.5f);
        声音.BGM音量 = ES3.Load<float>("BGM音量", 0.5f);
    }
    public void save() //保存存档
    {
        ES3.Save<int>("天赋点", 玩家.天赋点);
        ES3.Save<int>("真实天赋点", 玩家.真实天赋点);
        ES3.Save<int>("攻击力加成", 玩家.攻击力加成);
        ES3.Save<int>("生命值加成", 玩家.生命值加成);
        ES3.Save<float>("SE音量", 声音.SE音量);
        ES3.Save<float>("BGM音量", 声音.BGM音量);
    }

}

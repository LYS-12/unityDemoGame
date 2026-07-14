using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 这是一个游戏数据管理类 是一个单例模式对象
/// </summary>
public class GameDataMgr
{
   private static GameDataMgr instance =new GameDataMgr();
    public static GameDataMgr Instance{ get => instance; }
    //音效数据对象
    public MusicData musicData;
    //排行榜数据对象
    public RankList rankData;
    private GameDataMgr()
    {
        //在构造函数中初始化数据
        musicData=PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"Music") as MusicData;
        //如果没有数据 就创建一个默认的数据
        if(!musicData.notFirst)
        {
            //手动创建一个默认的数据
            musicData.notFirst = true;
            musicData.isOpenBk = true;
            musicData.isOpenSound = true;
            musicData.bkValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }
        //初始化 读取 排行榜数据
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }



    public void AddRankInfo(string name,int score,float time)
    {
        rankData.list.Add(new RankInfo(name, score, time));

        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        //只保留前10条数据
        for (int i= rankData.list.Count-1;i>=10 ;i--)
        {
            rankData.list.RemoveAt(i);
        }
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");

    }












    //提供一些API给外部 方便数据的改变存储
    public void OpenOrCloseBkMusic(bool isOpen)
    {
        musicData.isOpenBk= isOpen;

        BKMusic.Instance.ChangeOpen(isOpen);

        PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
    }
    public void OpenOrCloseBkSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    public void ChangeBkValue(float value)
    {
        musicData.bkValue= value;

        BKMusic.Instance.ChangeValue(value);

        PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
    }
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

}

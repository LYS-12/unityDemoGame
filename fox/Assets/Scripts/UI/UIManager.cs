using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance = new UIManager();
    public static UIManager Instance => instance;

    //存储面板的容器
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    private Transform canvasTrans;
    private UIManager()
    {
        canvasTrans = GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(canvasTrans.gameObject);
    }
    //显示
    public T ShowPanel<T>() where T : BasePanel
    {
        //保证泛型T的类型和面板名一致 定义一个这样的规则方便使用
        string panelName = typeof(T).Name; 
        if (panelDic.ContainsKey(panelName))
        {  
            return panelDic[panelName] as T;
        }
        //显示面板 就是 动态的创建面板预设体 设置父对象
        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
        panelObj.transform.SetParent(canvasTrans, false);

        //得到对应的面板脚本
        T panel = panelObj.GetComponent<T>();
        panelDic.Add(panelName, panel);
        panel.ShowMe();
        return panel;
    }
    //隐藏
    public void HidePanel<T>(bool isFade = true) where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            BasePanel panel = panelDic[panelName];
            if (panelDic.ContainsKey(panelName))
            {
                if (isFade)
                {
                    panelDic[panelName].HideMe(() =>
                    {
                        GameObject.Destroy(panelDic[panelName].gameObject);
                        panelDic.Remove(panelName);
                    });
                }
                else
                {
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    panelDic.Remove(panelName);
                }
            }

        }
    }
    //获得
    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }
        return null;
    }
}

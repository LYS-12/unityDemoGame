using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{

    private static T instance;
    public static T Instance=>instance;

    private void Awake()
    {
        //在Awake中初始化的原因是
        //我们的面板脚本在场景上肯定只会挂载一次
        //那么我们可以在这个脚本的生命周期函数的Awake中
        //直接记录场景上 唯一的这个脚本
        instance = this as T;
    }

    public virtual void ShowMe()
    {
        gameObject.SetActive(true);
    }
    public virtual void HideMe()
    {
        gameObject.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private float alphaSpeed = 10f;
    private bool isShow = false;
    //淡出成功时执行的委托函数
    private UnityAction hideCallBack;
    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if(canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }
    /// <summary>
    /// 主要用于初始化面板的内容，子类需要实现该方法
    /// </summary>
    public abstract void Init();
    /// <summary>
    /// 显示自己时做的事情
    /// </summary>
    public virtual void ShowMe()
    {
        isShow = true;
        canvasGroup.alpha = 0;
        gameObject.SetActive(true);
    }
    /// <summary>
    /// 隐藏自己时做的事情
    /// </summary>
    public virtual void HideMe(UnityAction callBack)
    {
        isShow = false;
        canvasGroup.alpha = 1;
        //记录 传入的淡出成功后的委托函数
        hideCallBack = callBack;
    }
    // Update is called once per frame
    void Update()
    {
        //淡入
        if (isShow&&canvasGroup.alpha!=1) 
        {
            canvasGroup.alpha += Time.deltaTime * alphaSpeed;
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 1;
            }
        }
        //淡出
        else if (!isShow)
        {
            canvasGroup.alpha -= Time.deltaTime * alphaSpeed;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                //通过管理器删除
                hideCallBack?.Invoke();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public ClearCounter k1;
    public ClearCounter k2;
    public ClearCounter k3;
    // 在Inspector赋值你ScriptObject文件夹下的Fox SO
    public KitchenObjectSO FoxSO;

    void Update()
    {
        // 获取三个台子当前物品SO
        KitchenObjectSO obj1 = k1.GetCurrentObjectSO();
        KitchenObjectSO obj2 = k2.GetCurrentObjectSO();
        KitchenObjectSO obj3 = k3.GetCurrentObjectSO();

        // 判断：三个台子都有物品，且全部是Fox
        if (obj1 == FoxSO && obj2 == FoxSO && obj3 == FoxSO)
        {
            UIManager.Instance.ShowPanel<ChoosePanel>();
            // 可选：只触发一次，避免Update每帧重复打开面板
            enabled = false;
        }
    }
}
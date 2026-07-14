using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next1 : MonoBehaviour
{
    public ClearCounter tomo;
    public ClearCounter chee;
    public ClearCounter bread;
    // 在Inspector赋值你ScriptObject文件夹下的Fox SO
    public KitchenObjectSO tomoSO;
    public KitchenObjectSO cheeSO;
    public KitchenObjectSO breadSO;

    void Update()
    {
        // 获取三个台子当前物品SO
        KitchenObjectSO obj1 = tomo.GetCurrentObjectSO();
        KitchenObjectSO obj2 = chee.GetCurrentObjectSO();
        KitchenObjectSO obj3 = bread.GetCurrentObjectSO();

        // 判断：三个台子都有物品，且全部是Fox
        if (obj1 == tomoSO && obj2 == cheeSO && obj3 == breadSO)
        {
            UIManager.Instance.ShowPanel<ChoosePanel>();
            // 可选：只触发一次，避免Update每帧重复打开面板
            enabled = false;
        }
    }
}
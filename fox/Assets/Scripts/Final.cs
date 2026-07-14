using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public ClearCounter k1;
    // Start is called before the first frame update

    public KitchenObjectSO Cheese;
    // Update is called once per frame
    void Update()
    {
        // 获取三个台子当前物品SO
        KitchenObjectSO obj1 = k1.GetCurrentObjectSO();

        // 判断：三个台子都有物品，且全部是Fox
        if (obj1 == Cheese)
        {
            UIManager.Instance.ShowPanel<FinalPanel>();
            // 可选：只触发一次，避免Update每帧重复打开面板
            enabled = false;
        }
    }
}

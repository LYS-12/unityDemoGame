using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 提升玩家属性类 : 升级项base
{
    public override void 选择升级()
    {
        player = GameObject.Find("玩家对象层").transform.GetChild(0).gameObject.GetComponent<Player>();
        battleUI = GameObject.Find("battleUI").GetComponent<battleUI>();
        switch (玩家属性)
        {
            case 玩家升级属性.shengminh:
                player.shengmaxh += (int)提升数值;
                player.shengminh += (int)提升数值;
                break;
            case 玩家升级属性.baoji:
                player.baoji +=提升数值;
                break;
            case 玩家升级属性.attack:
                player.attack += (int)提升数值;
                break;
            case 玩家升级属性.shanbi:
                player.shanbi += 提升数值;
                break;
            case 玩家升级属性.fangyu:
                player.fangyu += (int)提升数值;
                break;
        }
        关闭三选一();
    }
}

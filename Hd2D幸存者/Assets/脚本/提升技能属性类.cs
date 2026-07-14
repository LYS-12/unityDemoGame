using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 提升技能属性类 : 升级项base
{
    public override void 选择升级()
    {
        player = GameObject.Find("玩家对象层").transform.GetChild(0).gameObject.GetComponent<Player>();
        battleUI = GameObject.Find("battleUI").GetComponent<battleUI>();
        Skillbase 目标技能 =null;
        foreach (Transform skill in player.技能表)
        {
            Skillbase s =skill.GetComponent<Skillbase>();
            if (对应技能.Skillname == s.Skillname)
            {
                目标技能 = s;
            }
        }
        switch (技能属性)
        {
            case 技能升级属性.伤害:
                目标技能.damage += (int)提升数值;
                break;
            case 技能升级属性.大小:
                目标技能.size += 提升数值;
                break;
            case 技能升级属性.穿透:
                目标技能.pass += (int)提升数值;
                break;
            case 技能升级属性.数量:
                目标技能.number += (int)提升数值;
                break;
            case 技能升级属性.生命周期:
                目标技能.lifetime += 提升数值;
                break;
        }
        关闭三选一();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropType
{
    //加属性的4种类型
    Atk,
    Def,
    MaxHp,
    Hp
}
public class PropReward : MonoBehaviour
{
    //默认添加的值 获取道具后
    public int changeValue = 2;
    public E_PropType type = E_PropType.Atk;
    //获取特效
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        //玩家才能获取属性奖励
        if (other.CompareTag("Player"))
        {
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (type)
            {
                case E_PropType.Atk:
                    player.atk += changeValue;
                    break;
                case E_PropType.Def:
                    player.def += changeValue;
                    break;
                case E_PropType.MaxHp:
                    player.maxHp += changeValue;
                    GamePanel.Instance.UpdateHP(player.maxHp, player.hp);
                    break;
                case E_PropType.Hp:
                    player.hp += changeValue;
                    if (player.hp > player.maxHp)
                        player.hp = player.maxHp;
                    GamePanel.Instance.UpdateHP(player.maxHp, player.hp);
                    break;
            }
            //创建特效
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //设置音效
            AudioSource audioS = eff.GetComponent<AudioSource>();
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            Destroy(this.gameObject);
        }
    }
}

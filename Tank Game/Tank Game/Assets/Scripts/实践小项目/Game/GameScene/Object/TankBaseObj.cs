using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHp;
    public int hp;

    public Transform tankHead;

    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    public GameObject deadEff;
    /// <summary>
    /// 开火抽象方法
    /// </summary>
    public abstract void Fire();
    /// <summary>
    /// 我被别人攻击
    /// </summary>
    /// <param name="other"></param>
    public virtual void Wound(TankBaseObj other)
    {
        int dmg = other.atk - this.def;
        if (dmg <= 0)
            return;
        //如果伤害大于0
        this.hp -= dmg;
        if (this.hp <= 0)
        {
            this.hp = 0;
            this.Dead();
        }

    }
    /// <summary>
    /// 死亡方法
    /// </summary>
    public virtual void Dead()
    {
        //销毁对象
        Destroy(this.gameObject);
        if (deadEff != null)
        {
            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            //特效关联了音效 控制音效代码
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{


    //不用管自动旋转

    //间隔开火
    // 应该有一个 间隔时间
    public float fireOffsetTime = 1;
    //发射位置
    public Transform[] shootPos;
    //子弹预设体 关联
    public GameObject bulletObj;

    private float nowTime=0;



    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime >= fireOffsetTime) 
        {
            Fire();
            nowTime = 0;
        }
    } 
    public override void Fire()
    {
       for (int i = 0; i < shootPos.Length; i++)
        {
           GameObject obj=  Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //设置子弹的攻击力
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);



        }
    }

    public override void Wound(TankBaseObj other)
    {
        //让固定坦克不会死亡
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 齿轮子弹 : Bulletbase
{
    public float 环绕半径;
    public float 初始环绕角度 = 0;
    public override void GetFather()//获取父技能身上的属性
    {
        damage = fatherskill.damage;
        level = fatherskill.level;
        lifetime = fatherskill.lifetime;
        pass = fatherskill.pass;
        speed = fatherskill.speed;
        size = fatherskill.size;
        环绕半径 = fatherskill.GetComponent<Skill_黑暗齿轮>().环绕半径;
        player = GameObject.Find("玩家对象层").transform.GetChild(0).GetComponent<角色基类>();
        rb = GetComponent<Rigidbody>();
        怪物层 = GameObject.Find("怪物层").transform;
    }

     void FixedUpdate()
    {
        if (cango)
        {
            初始环绕角度 += speed * Time.fixedDeltaTime;
            Vector3 position1 = player.transform.position +new Vector3(环绕半径*Mathf.Cos(初始环绕角度),2,环绕半径*Mathf.Sin(初始环绕角度));
            transform.position = position1;

            Vector3 朝向向量 = new Vector3(Mathf.Cos(初始环绕角度),0,Mathf.Sin(初始环绕角度)).normalized;
            transform.forward = new Vector3(0, 0, 朝向向量.z + 180);
            //transform.right = 朝向向量;
            lifetime -= Time.fixedDeltaTime;
            if (lifetime <= 0)
            {
                销毁自己();
            }
        }

        
    }
}

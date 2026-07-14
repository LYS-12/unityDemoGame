using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillbase : MonoBehaviour
{
    public string Skillname;
    public float CDtime;
    public float CDkey;
    public int damage;
    public int level;
    public float lifetime;
    public int pass;
    public float speed;
    public int number;
    public GameObject bullet;//子弹
    public float size;//子弹大小
    public float interval;//间隔时间
    public GameObject player;
    public float angle;//旋转角度
    public bool 是否朝向最近敌人;
    public Sprite icon;
     void FixedUpdate()
    {
        CDkey += Time.fixedDeltaTime;
        if (CDkey > CDtime)
        {
            CDkey = CDtime;
        }
    }

    public virtual IEnumerator UseSkill() //使用技能
    {
        CDkey = 0;
        for (int i = 0; i < number; i++)
        {
            GameObject newbullet = Instantiate(bullet, player.transform.position,Quaternion.Euler(new Vector3(0,0,angle)));
            Bulletbase n = newbullet.GetComponent<Bulletbase>();
            n.fatherskill = this;
            n.GetFather();
            n.获取目标();
            n.cango = true;    
            yield return new WaitForSeconds(interval);
        }

    }
}

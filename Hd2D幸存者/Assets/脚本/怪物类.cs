using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 怪物类 : 角色基类
{
    public GameObject 伤害数字;
    public 角色状态 状态;
    public GameObject 目标角色;
    private Transform 玩家层;
    private Animator ani;
    public float 缩放;
    public Material 普通材质;
    public Material 受击材质;

    public GameObject 掉落物;
    public AudioClip 被击音效;
    public enum 角色状态
    {
        闲置,
        移动,
        死亡,
    }
    void OnEnable()//当对象被激活时调用
    {
        玩家层 =GameObject.Find("玩家对象层").transform;
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player 玩家 = collision.gameObject.GetComponent<Player>();
            if (玩家.shengminh > 0)
            {
                玩家.shengminh -= attack;
                GameObject 数字 = Instantiate(伤害数字, collision.transform.position, default);
                数字.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = attack.ToString();
                collision.gameObject.GetComponent<Player>().开始受击反馈();
                if (玩家.shengminh <= 0)
                {
                    玩家.死亡事件();
                }
            }
        }
    }



    public void 开始受击反馈()
    {
        StartCoroutine(受击反馈());
        if (被击音效 != null)
        {
            GetComponent<AudioSource>().clip = 被击音效;
            GetComponent<AudioSource>().volume =GameObject.Find("声音管理").GetComponent<声音管理>().SE音量;
            GetComponent<AudioSource>().Play();
        }
    }
    public IEnumerator 受击反馈()
    {
        GetComponent<SpriteRenderer>().material = 受击材质;
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().material = 普通材质;
    }

    public void 死亡事件()
    {
        if (状态 != 角色状态.死亡)
        {


            状态 =角色状态.死亡;

            Instantiate(掉落物, transform.position, Quaternion.Euler(45, 0, 0));
            ani.SetTrigger("死亡");
            StartCoroutine(删除自己());
        }

    }
    public IEnumerator 删除自己()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    public void 获取目标()
    {
        float 最近距离 = 999;
        Transform 临时最近单位=null;
        if(玩家层.childCount> 0)
        {
            foreach(Transform item in 玩家层)
            {
                Vector3 i =item.position;
                float distance =Vector3.Distance(i,transform.position);
                if (distance < 最近距离)
                {
                    最近距离 =distance;
                    临时最近单位 = item;
                }
            }
            目标角色 = 临时最近单位.gameObject;

        }
    }
     void FixedUpdate()
    {
        if (玩家层.GetChild(0).GetComponent<Player>().玩家死亡 ==false) 
        {
            if (目标角色 != null)
            {
                //目标左，怪右
                float 差值 = 目标角色.transform.position.x - transform.position.x;
                if (差值 > 0)
                {
                    transform.localScale = new Vector3(缩放, 缩放, 缩放);
                }
                else
                {
                    transform.localScale = new Vector3(-1 * 缩放, 缩放, 缩放);
                }
            }
            switch (状态)
            {
                case 角色状态.闲置:

                    ani.SetBool("移动", false);


                    //如果怪物目标角色不存在，则获取目标
                    //如果存在，则改变状态为移动
                    if (目标角色 == null)
                    {
                        获取目标();
                    }
                    else
                    {
                        状态 = 角色状态.移动;
                    }
                    break;

                case 角色状态.移动:

                    ani.SetBool("移动", true);
                    //如果目标角色不存在，则改变状态为闲置
                    //如果目标角色存在，则移动自身靠近目标

                    if (目标角色 == null)
                    {
                        状态 = 角色状态.闲置;
                    }
                    else
                    {
                        //1、获取目标的坐标和自己的坐标
                        //2、设置一个移动向量
                        //3、把移动向量赋值给他的刚体
                        Vector3 position1 = 目标角色.transform.position;  //目标的坐标
                        Vector3 position2 = transform.position;  //自己的坐标
                        Vector3 distance = position1 - position2;
                        Vector3 向量 = new Vector3(distance.x, 0, distance.z).normalized * yidong_speed;
                        transform.position += 向量 * Time.fixedDeltaTime;

                    }
                    break;


                case 角色状态.死亡:
                    //不进行任何移动和行为
                    if (目标角色 == null)
                    {

                    }
                    else
                    {

                    }
                    break;

            }

        }


    }
}

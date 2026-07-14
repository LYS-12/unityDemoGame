using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 刷怪点 : MonoBehaviour
{

    public Transform 怪物层;
    public battleUI b;
    public List<GameObject> 怪物列表;
    public float 刷怪间隔;
    public int 同屏最大怪物数;
    public float 计时器;
    public Player player;

     void FixedUpdate()
    {
       if (b.允许倒计时 ==true && player.玩家死亡==false)
        {
            计时器 += Time.fixedDeltaTime;
            if (计时器 > 刷怪间隔) 
            {
                计时器 = 0;
                刷怪();
            }
        } 
    }

    public void 刷怪()
    {
        if(怪物层.childCount < 同屏最大怪物数)
        {

            Instantiate(获取随机对象(), 获取随机刷怪点().position,Quaternion.Euler(45,0,0), 怪物层);
        }
    }

    public GameObject 获取随机对象()
    {
        int 随机值 = Random.Range(0,怪物列表.Count);
        return 怪物列表[随机值];
    }

    public Transform 获取随机刷怪点()
    {
        int 随机值 = Random.Range(0, transform.childCount);
        return transform.GetChild(随机值);

    }
}

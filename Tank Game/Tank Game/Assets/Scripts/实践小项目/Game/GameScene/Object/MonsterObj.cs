using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MonsterObj : TankBaseObj
{


    //1.让坦克移动
    //当前的目标点
    private Transform targetPos;

    //随机用的点
    public Transform[] randomPos;
    //2.坦克盯着目标
    public Transform lookAtTarget;
    //3.间隔攻击

    public float fireDis = 5;

    public float fireOffsetTime = 1;
    private float nowTime = 0;

    //开火点
    public Transform[] shootPos;
    //子弹预设体
    public GameObject bulletObj;


    //血条
    public Texture maxHpBK;
    public Texture hpBK;

    private float showTime;

    //之所以没有NEW 结构体
    private Rect maxHpReat;
    private Rect hpReat;
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region 多个点之间的随机移动
        //朝面朝向位移
        this.transform.LookAt(targetPos);
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //知识点 Vector3里面有一个得到2个点之间距离的方法
        if (Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }
        #endregion

        #region 看向自己的目标
        if (lookAtTarget != null)
        {
            tankHead.LookAt(lookAtTarget);
            //当自己和目标距离等于开火距离时
            if (Vector3.Distance(this.transform.position, lookAtTarget.position) <= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffsetTime)
                {
                    nowTime = 0;
                    Fire();
                }
            }
        }



        #endregion
    }
    private void RandomPos()
    {
        if (randomPos == null)
            return;
        targetPos = randomPos[Random.Range(0, randomPos.Length)];

    }
    public override void Fire()
    {
        for (int i=0;i<shootPos.Length;i++)
        {
            GameObject obj=Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }

    public override void Dead()
    {
        base.Dead();
        //怪物死亡时加分
        GamePanel.Instance.AddScore(10);
    }

    /// <summary>
    /// 绘制血条
    /// </summary>
    private void OnGUI()
    {
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;
            //1.把怪物位置转换成屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //2.屏幕位置转换成GUI
            screenPos.y = Screen.height - screenPos.y;

            //绘制
            //知识点：GUI中的图片绘制
            //底图
            //思考：近大远小血条绘制
            maxHpReat.x = screenPos.x - 40;
            maxHpReat.y = screenPos.y - 60;
            maxHpReat.width = 100;
            maxHpReat.height = 15;
            GUI.DrawTexture(maxHpReat, maxHpBK);

            hpReat.x = screenPos.x - 40;
            hpReat.y = screenPos.y - 60;
            hpReat.width = (float)hp / maxHp * 100f;
            hpReat.height = 15;
            GUI.DrawTexture(hpReat, hpBK);
        }
    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //设置血条显示时间
        showTime = 3;

    }
}

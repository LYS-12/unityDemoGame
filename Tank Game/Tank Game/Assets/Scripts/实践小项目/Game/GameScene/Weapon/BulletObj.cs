using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{

    public float moveSpeed = 50;
    public TankBaseObj fatherObj;
    public GameObject effObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
    //和别人碰撞
    private void OnTriggerEnter(Collider other)
    {
        //子弹射击到立方体爆炸
        if (other.CompareTag("Cube")||
            other.CompareTag("Player") &&fatherObj.CompareTag("Monster")||
            other.CompareTag("Monster") && fatherObj.CompareTag("Player"))
        {
            //判断是否受伤
            //得到碰撞到的对象身上是否有坦克相关脚本

            TankBaseObj obj=other.GetComponent<TankBaseObj>();
            if (obj != null) 
                obj.Wound(fatherObj);
            


            //创建特效
            if (effObj!= null)
            {
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                //设置特效音量
                AudioSource audioS = eff.GetComponent<AudioSource>();
                audioS.volume = GameDataMgr.Instance.musicData.soundValue;

                audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }
            Destroy(this.gameObject);
        }
    }
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}

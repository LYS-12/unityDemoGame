using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //奖励物品预设体关联
    public GameObject[] rewardObjects;

    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        //1.销毁子弹
        //不用自己写


        //2.打到自己 应该处理 随机创建奖励的逻辑

        //随机一个数 来获取奖励
        int rangeInt = Random.Range(0, 100);
        //50%的概率创建一个奖励
        if (rangeInt < 50)
        {
            rangeInt = Random.Range(0, rewardObjects.Length);

            Instantiate(rewardObjects[rangeInt], this.transform.position, this.transform.rotation);
        }
        //创建特效预设体
        GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
        AudioSource audioS = effObj.GetComponent<AudioSource>();
        audioS.volume = GameDataMgr.Instance.musicData.soundValue;
        audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        Destroy(this.gameObject);

    }
}

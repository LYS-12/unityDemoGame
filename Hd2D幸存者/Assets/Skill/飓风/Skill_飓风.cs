using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_飓风 : Skillbase
{
    public override IEnumerator UseSkill() //使用技能
    {
        CDkey = 0;
        float 加角度 =360/number;
        float 当前角度 = 0;

        for (int i = 0; i < number; i++)
        {
            GameObject newbullet = Instantiate(bullet, player.transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
            Bulletbase n = newbullet.GetComponent<Bulletbase>();
            n.fatherskill = this;
            n.GetFather();
            n.获取目标();
            n.GetComponent<飓风子弹>().朝向角度=当前角度;
            n.cango = true;
            yield return new WaitForSeconds(interval);
            当前角度 += 加角度;
        }

    }
}

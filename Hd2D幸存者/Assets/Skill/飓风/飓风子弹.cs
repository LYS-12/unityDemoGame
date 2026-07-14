using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 飓风子弹 : Bulletbase
{
    public float 朝向角度;
    void FixedUpdate()
    {
        if (cango == true)
        {
            float 角度 = 朝向角度*Mathf.Deg2Rad;
            Vector3 向量 = new Vector3(Mathf.Cos(角度),0,Mathf.Sin(角度)).normalized;

            rb.velocity = 向量 * speed;
            lifetime -= Time.fixedDeltaTime;
            if (lifetime <= 0)
            {
                销毁自己();
            }
        }
    }
}

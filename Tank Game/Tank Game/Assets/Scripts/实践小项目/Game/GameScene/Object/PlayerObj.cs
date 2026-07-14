using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj 
{
  
    public WeaponObj nowWeapon;
    public Transform weaponPos;

    // Update is called once per frame
    void Update()
    {
        //前进后退

        this.transform.Translate(Input.GetAxis("Vertical")* Vector3.forward * moveSpeed * Time.deltaTime);


        //左右转向
        this.transform.Rotate( Input.GetAxis("Horizontal") *Vector3.up * roundSpeed * Time.deltaTime);

        //炮塔转向
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);

        //开火
        if (Input.GetMouseButtonDown(0))
        {
            this.Fire();
        }
    }
    public override void Fire()
    {
        if(nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }
    public override void Dead()
    {
        //base.Dead();
        //摄像机在，不能继承
        //处理失败
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();

    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GamePanel.Instance.UpdateHP(this.maxHp,this.hp );
    }
    /// <summary>
    /// 切换武器
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        //删除当前拥有的武器
        if(nowWeapon!=null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        //创建新的武器 创建子对象 false保留缩放大小
        GameObject weaponObj = Instantiate(weapon, weaponPos.transform,false);
        nowWeapon=weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}

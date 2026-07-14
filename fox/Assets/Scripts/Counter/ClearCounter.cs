using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//有东西
            if (IsHaveKitchenObject() == false)
            {
                TransformKitchenObject(player,this );
    
            }
            else
            {

            }
        }
        else
        {//没有东西
            if (IsHaveKitchenObject() == false)
            {

            }
            else
            {
                TransformKitchenObject(this,player );
            }

        }
    }

    // 获取当前台子物品的SO，无物品返回null
    public KitchenObjectSO GetCurrentObjectSO()
    {
        if (kitchenObject == null)
            return null;
        // 直接访问KitchenObject身上的SO字段，去掉多余Get()
        return kitchenObject.kitchenObjectSO;
    }
}

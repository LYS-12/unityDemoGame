using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public static int i = 0;
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject()) return;
        CreatKitchennObject(kitchenObjectSO.prefab);
        TransformKitchenObject(this, player);
        //销毁这个脚本
        Destroy(this);

    }
    public void CreatKitchennObject(GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}

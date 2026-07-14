using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject()) return;
        CreatKitchennObject(kitchenObjectSO.prefab);
        TransformKitchenObject(this, player);

    }
    public void CreatKitchennObject(GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}

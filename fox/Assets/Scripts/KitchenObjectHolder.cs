using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;
    public KitchenObject kitchenObject;
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public bool IsHaveKitchenObject()
    {
        return kitchenObject != null;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        if (kitchenObject == null)
        {
            return;
        }
        this.kitchenObject = kitchenObject;
        
        kitchenObject.transform.localPosition = Vector3.zero;
    }
    public Transform GetHoldPoint()
    {
        return holdPoint;
    }
    public void TransformKitchenObject(KitchenObjectHolder sourceHolder, KitchenObjectHolder targetHolder)
    {
        if (sourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning(sourceHolder + "原持有者上不存在食材，转移失败");
            return;
        }
        if (targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning(targetHolder + "目标持有者上存在食材，转移失败");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKitchenObject());
        //
        Vector3 targetForward = targetHolder.transform.forward;
        targetForward.y = 0;
        targetForward.Normalize();
        kitchenObject.transform.rotation= Quaternion.LookRotation(targetForward);
        //
        sourceHolder.ClearKitchenObject();
    }
    public void AddKitchenObject(KitchenObject kitchenObject)
    {

        kitchenObject.transform.SetParent(holdPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
 
        this.kitchenObject = kitchenObject;
    }

    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }
}


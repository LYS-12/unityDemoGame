using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxLook : MonoBehaviour
{

    public Transform foxHead;
    public Transform lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtTarget != null)
        {
            foxHead.LookAt(lookAtTarget);

        }

    }
}

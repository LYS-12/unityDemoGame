using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targetPlayer;
    public float H = 17;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targetPlayer == null)
            return;
        pos.x = targetPlayer.position.x;
        pos.y = H;
        pos.z = targetPlayer.position.z;
        this.transform.position = pos;
    }
}

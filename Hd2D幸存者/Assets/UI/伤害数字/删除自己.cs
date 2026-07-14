using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 删除自己 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(删除());
    }
    public IEnumerator 删除()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}

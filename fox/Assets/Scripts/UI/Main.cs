using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 5秒后调用ShowPanelLogic方法
        Invoke(nameof(ShowPanelLogic), 5f);
    }

    void ShowPanelLogic()
    {
        StartPanel startPanel = UIManager.Instance.ShowPanel<StartPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

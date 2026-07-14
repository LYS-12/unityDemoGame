using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePanel : BasePanel
{
    public Button btnCard1;
    public Button btnCard2;
    public Button btnCard3;
    public override void Init()
    {
        // 按钮1：加载GameScene1
        btnCard1.onClick.AddListener(() =>
        {
            // 1. 立刻隐藏面板（先把UI遮掉，视觉不卡）
            UIManager.Instance.HidePanel<ChoosePanel>();


            // 2. 销毁RawImage（提前处理，不占用加载帧）
            GameObject rawObj = GameObject.Find("RawImage");
            if (rawObj != null)
            {
                Destroy(rawObj);
            }
            Loader.Load(Loader.Scene.GameScene1);

            UIManager.Instance.ShowPanel<OrderPanel1>();

        });

        // 按钮2：加载GameScene2
        btnCard2.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ChoosePanel>();

            UIManager.Instance.HidePanel<OrderPanel1>();
            GameObject rawObj = GameObject.Find("RawImage");
            if (rawObj != null)
            {
                Destroy(rawObj);
            }
            Loader.Load(Loader.Scene.GameScene2);


            UIManager.Instance.ShowPanel<OrderPanel2>();
        });

        // btnCard3 同理补充
        btnCard3.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ChoosePanel>();

            UIManager.Instance.HidePanel<OrderPanel2>();
            GameObject rawObj = GameObject.Find("RawImage");
            if (rawObj != null)
            {
                Destroy(rawObj);
            }
            Loader.Load(Loader.Scene.GameScene3);

            UIManager.Instance.ShowPanel<OrderPanel3>();
        });
    }

    /// <summary>
    /// 异步加载场景协程，不会阻塞主线程，解决卡顿
    /// </summary>
    IEnumerator LoadSceneAsync(string sceneName)
    {
        // 异步开始加载场景，后台加载，游戏画面不会卡死
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        // 禁止加载完成后自动切换场景（可选，可加加载进度条）
        asyncLoad.allowSceneActivation = false;

        // 循环等待加载进度完成
        while (asyncLoad.progress < 0.9f)
        {
            yield return null; // 每一帧释放主线程，不卡顿
        }

        // 资源加载完毕，再切换场景
        asyncLoad.allowSceneActivation = true;
    }
}

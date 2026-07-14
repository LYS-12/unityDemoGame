using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
   public enum Scene
    {
        StartScene,
        GameScene1,
        GameScene2,
        GameScene3,
        LoadingScene,
    }
    private static Scene targetScene;
    public static void Load(Scene target)
    {
        targetScene = target;
        SceneManager.LoadScene((int)Scene.LoadingScene);

    }
    public static void LoadBacke()
    {
        SceneManager.LoadScene((int)targetScene);
    }
}

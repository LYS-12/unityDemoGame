using UnityEditor;
using UnityEngine;

public class BatchRename : ScriptableWizard
{
    public string prefix = "labScore";
    public int startNum = 1;

    [MenuItem("Tools/批量重命名")]
    static void OpenWin()
    {
        DisplayWizard<BatchRename>("批量改名工具");
    }
    void OnWizardCreate()
    {
        var objs = Selection.gameObjects;
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].name = $"{prefix}{startNum + i}";
        }
    }
}
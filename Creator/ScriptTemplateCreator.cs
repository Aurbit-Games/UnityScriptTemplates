using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public static class ScriptTemplateCreator
{
    [MenuItem("Assets/Create/Script/MonoBehaviour", priority = 1)]
    public static void CreateMonoBehaviorItem()
    {
        string path = "Assets/Scripts/Editor/Custom Script Templates/Templates/MonoBehaviour.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewMonoBehaviour.cs");
    }
    [MenuItem("Assets/Create/Script/Class", priority = 2)]
    public static void CreateClassItem()
    {
        string path = "Assets/Scripts/Editor/Custom Script Templates/Templates/Class.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewClass.cs");
    }
    [MenuItem("Assets/Create/Script/Interface", priority = 3)]
    public static void CreateInterfaceItem()
    {
        string path = "Assets/Scripts/Editor/Custom Script Templates/Templates/Interface.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewInterface.cs");
    }
    [MenuItem("Assets/Create/Script/Scriptable Object", priority = 4)]
    public static void CreateScriptableObjectItem()
    {
        string path = "Assets/Scripts/Editor/Custom Script Templates/Templates/ScriptableObject.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewScriptableObject.cs");
    }
    [MenuItem("Assets/Create/Script/Editor Window", priority = 5)]
    public static void CreateEditorWindowItem()
    {
        string path = "Assets/Scripts/Editor/Custom Script Templates/Templates/EditorWindow.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewEditorWindow.cs");
    }
    [MenuItem("Assets/Create/Script/Custom Editor", priority = 6)]
    public static void CreateCustomEditrItem()
    {
        string path = "Assets/Scripts/Editor/Custom Script Templates/Templates/CustomEditor.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewCustomEditor.cs");
    }

}

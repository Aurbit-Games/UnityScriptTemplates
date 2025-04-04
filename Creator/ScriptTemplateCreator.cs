using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


#if UNITY_EDITOR
using UnityEditor;
#endif
public static class ScriptTemplateCreator
{
    public const string Path = "Assets/Scripts/Editor/ScriptTemplates/Templates";
    public static string GetTemplatePath(string template)
    {
        return $"{Path}/{template}.cs.txt";
    }
    [MenuItem("Assets/Create/Script/MonoBehaviour", priority = 1)]
    public static void CreateMonoBehaviorItem()
    {
        string path = GetTemplatePath("MonoBehaviour");

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewMonoBehaviour.cs");
    }
    [MenuItem("Assets/Create/Script/Class", priority = 2)]
    public static void CreateClassItem()
    {
        string path = GetTemplatePath("Class");

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewClass.cs");
    }
    [MenuItem("Assets/Create/Script/Interface", priority = 3)]
    public static void CreateInterfaceItem()
    {
        string path = GetTemplatePath("Interface");

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewInterface.cs");
    }
    [MenuItem("Assets/Create/Script/Scriptable Object", priority = 4)]
    public static void CreateScriptableObjectItem()
    {
        string path = GetTemplatePath("ScriptableObject");

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewScriptableObject.cs");
    }
    [MenuItem("Assets/Create/Script/Editor Window", priority = 5)]
    public static void CreateEditorWindowItem()
    {
        string path = GetTemplatePath("EditorWindow");

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewEditorWindow.cs");
    }
    [MenuItem("Assets/Create/Script/Custom Editor", priority = 6)]
    public static void CreateCustomEditrItem()
    {
        string path = GetTemplatePath("CustomEditor");

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewCustomEditor.cs");
    }

}

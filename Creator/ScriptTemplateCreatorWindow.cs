using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
public class ScriptTemplateCreatorWindow : EditorWindow
{
    private string _templateName;
    private string _templateScript;
    private string _templateCreatorPath;
    private string _templatesFolderPath;

    private Object source;
    private TextAsset _templateAsset;
    private Vector2 _scroll;

    private int _priorityIndex = 20;
    #region Code Blocks
    private const string ExampleTemplate = @"using UnityEngine;

#ROOTNAMESPACEBEGIN#
public class #SCRIPTNAME#
{
    public void SomeMethod()
    {
#NOTRIM#
    }
}
#ROOTNAMESPACEEND#";
    #endregion
    [MenuItem("Tools/Script Template Creator")]
    public static void ShowWindow()
    {
        GetWindow<ScriptTemplateCreatorWindow>("Script Template Creator");
    }
    private void OnEnable()
    {
        _templateCreatorPath = GetCorrectCreatorPath();
        _templatesFolderPath = _templateCreatorPath.Replace("Creator/ScriptTemplateCreator.cs", "Templates");
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        GUIStyle headerStyle = new GUIStyle(GUI.skin.label);
        headerStyle.alignment = TextAnchor.MiddleCenter;
        headerStyle.fontSize = 26;

        GUILayout.Label("Script Template Creator", headerStyle);
        GUILayout.Space(10);


        GUILayout.Space(10);
        _templateName = EditorGUILayout.TextField("Template Script", _templateName);
        GUILayout.Space(10);

        EditorGUILayout.HelpBox(@"You can select a script or text asset to edit its code here or write one by yourself.", MessageType.Info);
        EditorGUILayout.HelpBox(@"Place the following markers in the appropriate place:
#SCRIPTNAME# = Script Name (The name that you create the script with)
#ROOTNAMESPACEBEGIN# = Beginning of root namespace
#ROOTNAMESPACEEND# = Ending of root namespace
#NOTRIM# = Mark lines that end in whitespace", MessageType.Info);
        if (GUILayout.Button("Show Example"))
        {
            ShowExample();  
        }
        GUILayout.Space(10);
        GUILayout.Label("Template Code");
        source = EditorGUILayout.ObjectField(source, typeof(Object), true);

        TextAsset newTextAsset = null;
        if (source != null)  newTextAsset = (TextAsset)source;

        if (newTextAsset != _templateAsset && newTextAsset != null)
        {
            ReadTextAsset(newTextAsset);
        }
        if (newTextAsset == null && _templateScript != ExampleTemplate)
        {
            _templateScript = @"Select a script or text asset or write one.";
        }

        _scroll = EditorGUILayout.BeginScrollView(_scroll);
        _templateScript = EditorGUILayout.TextArea(_templateScript, GUILayout.ExpandHeight(true));
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Create"))
        {
            if (string.IsNullOrEmpty(_templateName))
            {
                Debug.LogWarning("The template should have a name.");
                return;
            }
            if (string.IsNullOrEmpty(_templateScript))
            {
                Debug.LogWarning("The template should have a script.");
                return;
            }

            string creatorContent = File.ReadAllText(_templateCreatorPath);

            int lastBraceIndex = creatorContent.LastIndexOf("}");

            creatorContent = creatorContent.Insert(lastBraceIndex - 1, GetMenuItemMethod(true));

            File.WriteAllText(_templateCreatorPath, creatorContent);

            AssetDatabase.Refresh();
        }
    }

    private string GetCorrectCreatorPath()
    {
        MonoScript script = MonoScript.FromScriptableObject(this);
        string path = AssetDatabase.GetAssetPath(script);

        path = path.Replace("ScriptTemplateCreatorWindow.cs", "ScriptTemplateCreator.cs");

        return path;
    }

    private void ReadTextAsset(TextAsset textAsset)
    {
        _templateScript = textAsset.text;
        _templateAsset = textAsset;
    }
    private void ShowExample()
    {
        _templateScript = ExampleTemplate;
    }
    private string GetMenuItemMethod(bool createTemplateTextFile)
    {
        string identifier = _templateName.Replace(" ", "");
        string method = $@"
    #region {_templateName}
    [MenuItem(""Assets/Create/Script/{_templateName}"", priority = {_priorityIndex})]
    public static void Create{identifier}Item()
    {{
        string path = ""{_templatesFolderPath}/{identifier}.cs.txt"";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, ""New{identifier}.cs"");
    }}
    #endregion
";
        _priorityIndex++;

        if (createTemplateTextFile)
        {
            string path = $"{_templatesFolderPath}/{identifier}.cs.txt";

            File.WriteAllText(path, _templateScript);
        }
        return method;
    }
} 
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;
using System;

public class ScriptableObjectWindow : EditorWindow
{
    private Editor[] editorArr;
    [SerializeField]
    private Object[] settingsArr;
    private int numObjects = 2;
    private string soPathsKey = "soPaths";

    private static GUIStyle _soContainer;
    private static GUIStyle soContainer
    {
        get
        {
            if (_soContainer == null)
                _soContainer = new GUIStyle(GUI.skin.box);

            return _soContainer;
        }
    }


    [MenuItem("Skill System/Scriptable Object Window")]
    private static void Init()
    {
        Type inspectorType = Type.GetType("UnityEditor.InspectorWindow,UnityEditor.dll");
        GetWindow<ScriptableObjectWindow>(inspectorType);
        var window = (ScriptableObjectWindow)GetWindow(typeof(ScriptableObjectWindow));
        window.Show();
    }


    private void OnEnable()
    {
        titleContent = new GUIContent("Scriptable Object Window");

        if (EditorPrefsExist())
        {
            LoadObjectsFromEditorPrefs();
        }
        else
        {
            SetObjectArray();
        }
    }

    private void OnGUI()
    {

        GUILayout.BeginVertical(soContainer);

        RenderObjectNumberField();
        RenderObjectFields();

        GUILayout.EndVertical();


        for (int i = 0; i < settingsArr.Length; i++)
        {
            if (settingsArr[i] != null)
            {
                GUILayout.Label(settingsArr[i].name);
                GUILayout.BeginVertical(soContainer);

                if (editorArr[i] == null)
                    editorArr[i] = Editor.CreateEditor(settingsArr[i]);

                editorArr[i].OnInspectorGUI();
                GUILayout.EndVertical();
            }
        }
    }

    private bool EditorPrefsExist()
    {
        return EditorPrefs.HasKey(soPathsKey);
    }

    private void LoadObjectsFromEditorPrefs()
    {
        var soPaths = EditorPrefs.GetString(soPathsKey);
        string[] paths = soPaths.Split(',');
        numObjects = paths.Length;

        settingsArr = new Object[numObjects];
        editorArr = new Editor[numObjects];

        for (int i = 0; i < settingsArr.Length; i++)
        {
            if (System.IO.File.Exists(paths[i]))
            {
                settingsArr[i] = AssetDatabase.LoadAssetAtPath<ScriptableObject>(paths[i]);
            }

        }

    }

    private void SetEditorPrefs()
    {
        string paths = "";
        for (int i = 0; i < numObjects; i++)
        {
            string comma = ",";

            // Ignore the comma for the last object
            if (i == numObjects - 1)
                comma = "";

            paths += AssetDatabase.GetAssetPath(settingsArr[i]) + comma;
        }



        if (!string.IsNullOrEmpty(paths))
        {
            EditorPrefs.SetString(soPathsKey, paths);
            Debug.Log("Recorded SO paths: " + paths);
        }
    }

    /// <summary>
    /// Creates arrays to be used in displaying object fields
    /// </summary>
    private void SetObjectArray()
    {
        settingsArr = new Object[numObjects];
        editorArr = new Editor[numObjects];

        for (int i = 0; i < numObjects; i++)
        {
            if (settingsArr[i] == null)
            {
                settingsArr[i] = new Object();
                editorArr[i] = null;
            }

        }
    }

    private void RenderObjectNumberField()
    {
        EditorGUI.BeginChangeCheck();
        numObjects = EditorGUILayout.IntField("Number of Objects", numObjects);

        if (EditorGUI.EndChangeCheck())
        {
            SetObjectArray();
        }
    }

    private void RenderObjectFields()
    {
        for (int i = 0; i < numObjects; i++)
        {
            EditorGUI.BeginChangeCheck();
            settingsArr[i] = EditorGUILayout.ObjectField("Scriptable Object", settingsArr[i], typeof(Object), false);

            if (EditorGUI.EndChangeCheck())
            {
                SetEditorPrefs();
            }
        }
    }
}
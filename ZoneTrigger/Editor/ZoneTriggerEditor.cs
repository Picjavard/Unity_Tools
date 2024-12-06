using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(ZoneTrigger))]
public class ZoneTriggerEditor : Editor
{
    private ZoneTrigger zoneTrigger;
    private List<string> availableComponents;

    private void OnEnable()
    {
        zoneTrigger = (ZoneTrigger)target;

        // Ищем все C# скрипты в папке Assets/Scripts
        string[] guids = AssetDatabase.FindAssets("t:MonoScript", new[] { "Assets/Scripts" });
        availableComponents = new List<string>();

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
            if (script != null)
            {
                Type type = script.GetClass();
                // Проверяем, что это MonoBehaviour и оно не абстрактное
                if (type != null && typeof(MonoBehaviour).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    availableComponents.Add(type.Name);
                }
            }
        }

        availableComponents.Sort(); // Сортируем список по алфавиту
    }


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.LabelField("Target Components", EditorStyles.boldLabel);

        if (availableComponents == null || availableComponents.Count == 0)
        {
            EditorGUILayout.HelpBox("No available components found in the project.", MessageType.Warning);
            return;
        }

        for (int i = 0; i < zoneTrigger.targetScriptNames.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            // Выпадающий список
            int selectedIndex = availableComponents.IndexOf(zoneTrigger.targetScriptNames[i]);
            if (selectedIndex < 0) selectedIndex = 0;

            selectedIndex = EditorGUILayout.Popup("Component", selectedIndex, availableComponents.ToArray());
            zoneTrigger.targetScriptNames[i] = availableComponents[selectedIndex];

            // Кнопка для удаления компонента
            if (GUILayout.Button("Remove", GUILayout.Width(70)))
            {
                zoneTrigger.targetScriptNames.RemoveAt(i);
                i--;
            }

            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Component"))
        {
            zoneTrigger.targetScriptNames.Add(availableComponents[0]);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(zoneTrigger);
        }
    }
}

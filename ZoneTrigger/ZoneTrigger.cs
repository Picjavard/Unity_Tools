using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneTrigger : MonoBehaviour
{
    [Serializable]
    public class TriggerEvent : UnityEvent<GameObject> { }
     
    [Tooltip("Список имен компонентов, на которые будет реагировать триггер.")]
    [SerializeField]
    public List<string> targetScriptNames = new List<string>(); // Список целевых скриптов

    [Tooltip("Событие, вызываемое при входе в триггер.")]
    public TriggerEvent OnEnter;

    [Tooltip("Событие, вызываемое при выходе из триггера.")]
    public TriggerEvent OnExit;

    private void OnTriggerEnter(Collider other)
    {
        if (HasAnyTargetScript(other.gameObject))
        {
            OnEnter.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (HasAnyTargetScript(other.gameObject))
        {
            OnExit.Invoke(other.gameObject);
        }
    }

    private bool HasAnyTargetScript(GameObject obj)
    {
        // Проверяем наличие хотя бы одного из указанных скриптов
        foreach (var scriptName in targetScriptNames)
        {
            if (obj.GetComponent(scriptName) != null)
            {
                return true;
            }
        }
        return false;
    }

    // Custom Inspector (необязательно)
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (targetScriptNames.Count == 0)
        {
            Debug.LogWarning("Список компонентов пуст! Укажите хотя бы один компонент для реакции ZoneTrigger.");
        }
    }
#endif
}

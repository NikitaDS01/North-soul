using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.Universal;

#if UNITY_EDITOR
[CustomEditor(typeof(WorkLight))]
public class EditorWorkLight : Editor
{
    private SerializedProperty _light = null;
    private SerializedProperty _workType = null;
    private SerializedProperty _period = null;

    private void OnEnable()
    {
        _light = serializedObject.FindProperty("_light");
        _workType = serializedObject.FindProperty("_workTypeLight");
        _period = serializedObject.FindProperty("_period");
    }
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.PropertyField(_light);
        EditorGUILayout.PropertyField(_workType);

        EditorGUILayout.BeginVertical("box");
        var value = (WorkLight.WorkTypeLight)_workType.enumValueIndex;
        switch (value)
        {
            case WorkLight.WorkTypeLight.DuringTime: DuringTime(); break;
            case WorkLight.WorkTypeLight.Standart: Touching(); break;
        }
        EditorGUILayout.EndVertical();

        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
    private void Touching()
    {

    }
    private void DuringTime()
    {
        EditorGUILayout.PropertyField(_period);
        EditorGUILayout.LabelField("Данный режим ещё не готов!");
    }
}
#endif
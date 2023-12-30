using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(Ladder))]
public class EditorWorkLadder : Editor
{
    private SerializedProperty _typeWork = null;
    private SerializedProperty _targetPosition = null;
    private SerializedProperty _offset = null;
    private SerializedProperty _targetObject = null;

    private void OnEnable()
    {
        _typeWork = serializedObject.FindProperty("_typeWork");
        _targetPosition = serializedObject.FindProperty("_targetPosition");
        _targetObject = serializedObject.FindProperty("_targetObject");
        _offset = serializedObject.FindProperty("_offset");
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.LabelField("Work ladder", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(_typeWork);

        EditorGUILayout.BeginVertical("box");
        var value = (Ladder.TypeWork)_typeWork.enumValueIndex;
        switch (value)
        {
            case Ladder.TypeWork.OnObject: WorkObject(); break;
            case Ladder.TypeWork.OnPosition: WorkPosition(); break;
        }
        EditorGUILayout.EndVertical();

        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
    private void WorkObject()
    {
        EditorGUILayout.PropertyField(_targetObject);
        EditorGUILayout.PropertyField(_offset);
    }
    private void WorkPosition()
    {
        EditorGUILayout.PropertyField(_targetPosition);
    }
}
#endif
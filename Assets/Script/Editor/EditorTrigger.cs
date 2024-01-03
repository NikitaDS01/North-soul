using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using static Ladder;

#if UNITY_EDITOR
[CustomEditor(typeof(Trigger))]
public class EditorTrigger : Editor
{
    private SerializedProperty _isButton = null;
    private SerializedProperty _isLoop = null;
    private SerializedProperty _tag = null;
    private SerializedProperty _typeCriterion = null;
    private SerializedProperty _nameAction = null;
    private SerializedProperty _item = null;
    private SerializedProperty _onNotWorkTrigger = null;
    private SerializedProperty _onWorkTrigger = null;

    private void OnEnable()
    {
        _isButton = serializedObject.FindProperty("_isButton");
        _isLoop = serializedObject.FindProperty("_isLoop");
        _tag = serializedObject.FindProperty("_tag");
        _typeCriterion = serializedObject.FindProperty("_typeCriterion");
        _nameAction = serializedObject.FindProperty("_nameAction");
        _item = serializedObject.FindProperty("_item");
        _onNotWorkTrigger = serializedObject.FindProperty("_onNotWorkTrigger");
        _onWorkTrigger = serializedObject.FindProperty("_onWorkTrigger");
    }
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.PropertyField(_isButton);
        EditorGUILayout.PropertyField(_isLoop);
        EditorGUILayout.PropertyField(_tag);

        EditorGUILayout.PropertyField(_typeCriterion);

        EditorGUILayout.BeginVertical("box");
        var value = (Trigger.TypeCriterion)_typeCriterion.enumValueIndex;
        switch (value)
        {
            case Trigger.TypeCriterion.PresentItem: Item(); break;
            case Trigger.TypeCriterion.DoneAction: Action(); break;
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.PropertyField(_onWorkTrigger);

        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
    private void Item()
    {
        EditorGUILayout.LabelField("Нужен предмет");
        EditorGUILayout.PropertyField(_item);
        NotWorkTrigger();
    }
    private void Action()
    {
        EditorGUILayout.LabelField("Выполнено действие");
        EditorGUILayout.PropertyField(_nameAction);
        NotWorkTrigger();
    }
    private void NotWorkTrigger()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("События, если условие не выполнено", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_onNotWorkTrigger);
    }
}
#endif
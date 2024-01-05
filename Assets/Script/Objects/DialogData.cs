using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Game/Dialog Data", order = 51)]
public class DialogData : ScriptableObject
{
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private DialogData _nextText;
    [SerializeField, TextArea(5,2)] private string _text = string.Empty;

    public string Name => _name;
    public DialogData NextText => _nextText;
    public string Text => _text;
    public bool IsEnd => _nextText == null;
}

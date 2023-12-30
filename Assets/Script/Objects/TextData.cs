using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Game/Dialog Data", order = 51)]
public class TextData : ScriptableObject
{
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private TextData _nextText;
    [SerializeField, TextArea(5,2)] private string _text = string.Empty;

    public string Name => _name;
    public TextData NextText => _nextText;
    public string Text => _text;
    public bool IsEnd => _nextText == null;
}

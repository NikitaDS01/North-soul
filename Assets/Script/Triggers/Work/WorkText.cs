using UnityEngine;

public class WorkText : AbstractWork
{
    [SerializeField] private TextData _data;
    public override void Run(GameEventArgs args)
    {
        var view = GameCore.PanelSingleton.TextView;
        StartCoroutine(view.PrintText(_data));
    }
}

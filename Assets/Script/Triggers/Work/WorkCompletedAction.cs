using UnityEngine;

public class WorkCompletedAction : AbstractWork
{
    [SerializeField] private string _action;
    public override void Run(GameEventArgs args)
    {
        var action = GameCore.CompletedActionSingleton;
        action.Add(_action);
    }
}
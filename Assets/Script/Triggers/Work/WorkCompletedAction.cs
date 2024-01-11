using UnityEngine;

public class WorkCompletedAction : AbstractAction
{
    [SerializeField] private string _action;
    public override void Run(GameEventArgs args)
    {
        GameController.AddAction(_action);
    }
}
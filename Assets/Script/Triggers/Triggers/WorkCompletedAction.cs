using UnityEngine;

public class WorkCompletedAction : Trigger
{
    [SerializeField] private string _action;
    protected override void Work()
    {
        eventBus.Invoke(new AddCompletedActionSignal(_action));
    }
}
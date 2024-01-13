using UnityEngine;

public class ActionCondition : MonoBehaviour, IConditionInteractable
{
    [SerializeField] private string _checkAction;
    private CompletedActions _actions;
    private void Start()
    {
        _actions = ServiceLocator.Singleton.Get<CompletedActions>();
    }
    public bool Check()
    {
        return _actions.Contain(_checkAction);
    }
}

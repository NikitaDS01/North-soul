using UnityEngine;

public class AddActionInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string _action;
    public void Work(EventBus eventBusIn)
    {
        var signal = new AddCompletedActionSignal(_action);
        eventBusIn.Invoke(signal);
    }
}

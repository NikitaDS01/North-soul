using System.Collections.Generic;

/// <summary>
/// Класс, нужен для хранения выполненых действий
/// </summary>
public class CompletedActions : IService, IContainEvent
{
    private List<string> _completedActionData;
    private EventBus _eventBus;
    public CompletedActions()
    {
        _completedActionData = new List<string>();
    }
    public void Init()
    {
        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
    }
    public bool Contain(string actionIn)
    {
        return _completedActionData.Contains(actionIn);
    }
    public void Add(string actionIn)
    {
        _completedActionData.Add(actionIn);
    }
    public void Add(AddCompletedActionSignal signal)
    {
        this.Add(signal.NameAction);
    }

    public void EnableEvent()
    {
        _eventBus.Subscribe<AddCompletedActionSignal>(Add);
    }
    public void DisableEvent()
    {
        _eventBus.Unsubcribe<AddCompletedActionSignal>(Add);
    }
}
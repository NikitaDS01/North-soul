using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour, IService, IContainEvent
{
    private EventBus _eventBus;
    private bool _menuActive;

    private void LateUpdate()
    {
        if (Input.GetKeyUp(Settings.KeyEcs))
        {
            if (_menuActive)
                _eventBus.Invoke(new DisableMenuSignal());
            else
                _eventBus.Invoke(new EnableMenuSignal());
        }
    }

    public void Init()
    {
        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
        _menuActive = false;
    }
    public void EnableEvent()
    {
        _eventBus.Subscribe<EnableMenuSignal>(Enable);
        _eventBus.Subscribe<DisableMenuSignal>(Disable);
    }
    public void DisableEvent()
    {
        _eventBus.Unsubcribe<EnableMenuSignal>(Enable);
        _eventBus.Unsubcribe<DisableMenuSignal>(Disable);
    }
    public void Enable(EnableMenuSignal signal) => _menuActive = true;
    public void Disable(DisableMenuSignal signal) => _menuActive = false;
}
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс, для вывода инвентаря
/// </summary>

[System.Serializable]
public class InventoryView : IService, IContainEvent
{
    [SerializeField] private GameObject _inventoryViewObject;
    [SerializeField] private Image[] _images;
    private EventBus _eventBus;

    public void ViewOn()
    {
        var playerObject = ServiceLocator.Singleton.Get<Player>();
        var inventory = playerObject.Inventory;
        _inventoryViewObject.SetActive(true);
        for(int index = 0; index < inventory.Count; index++)
        {
            ItemData item = inventory[index];
            _images[index].sprite = item.Icon;
        }
    }
    public void ViewOff()
    {
        _inventoryViewObject.SetActive(false);
        for (int index = 0; index < _images.Length; index++)
        {
            _images[index].sprite = null;
        }
    }
    public void Init()
    {
        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
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
    public void Enable(EnableMenuSignal signal) => ViewOn();
    public void Disable(DisableMenuSignal signal) => ViewOff();
}

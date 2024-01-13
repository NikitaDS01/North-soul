using UnityEngine;

public class GiveItemInteractable : MonoBehaviour, IInteractable, INotInteractable, IConditionInteractable
{
    [SerializeField] private ItemData _item;
    private Inventory _inventory;

    private void Start()
    {
        var player = ServiceLocator.Singleton.Get<Player>();
        _inventory = player.Inventory;
    }

    public bool Check()
    {
        return _inventory.IsTherePlace();
    }

    public void NotWork(EventBus eventBusIn)
    {
        var signal = new NotPlaceInventorySignal();
        eventBusIn.Invoke(signal);
    }

    public void Work(EventBus eventBusIn)
    {
        var signal = new AddItemInventorySignal(_item);
        eventBusIn.Invoke(signal);
    }
}

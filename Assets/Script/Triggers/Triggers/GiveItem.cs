using UnityEngine;

public class GiveItem : Trigger
{
    [Header("Дополнительно")]
    [SerializeField] private ItemData _item;

    private Inventory _inventory;
    protected override void InputData()
    {
        var player = ServiceLocator.Singleton.Get<Player>();
        _inventory = player.Inventory;
    }
    protected override bool Condition()
    {
        return _inventory.IsTherePlace();
    }
    protected override void Work()
    {
        eventBus.Invoke(new AddItemInventorySignal(_item));            
    }
    protected override void NotWork()
    {
        eventBus.Invoke(new NotPlaceInventorySignal());
    }
}
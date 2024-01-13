using UnityEngine;

public class PresentItemCondition : MonoBehaviour, IConditionInteractable
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
        return _inventory.Contain(_item);
    }
}

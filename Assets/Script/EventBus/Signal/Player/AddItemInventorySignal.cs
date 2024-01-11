public class AddItemInventorySignal
{
    private ItemData _item;
    public AddItemInventorySignal(ItemData item)
    {
        _item = item;
    }
    public ItemData Item => _item;
}
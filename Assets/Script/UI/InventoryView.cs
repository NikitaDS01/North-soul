using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс, для вывода инвентаря
/// </summary>
public class InventoryView
{
    private GameObject _inventoryViewObject;
    private Image[] _images;

    public InventoryView(GameObject inventoryObject, Image[] images)
    {
        _inventoryViewObject = inventoryObject;
        _images = images;
    }

    public void ViewOn()
    {
        var inventory = GameCore.PlayerSingleton.Inventory;
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
}

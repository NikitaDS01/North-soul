using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RegistryItem : IService
{
    private Dictionary<int, ItemData> _items;

    public RegistryItem()
    {
        _items = new Dictionary<int, ItemData>();
    }
    public void Init()
    {
        this.LoadFromFile();
    }
    public void LoadFromFile()
    {
        var objects = Resources.LoadAll("Items");
        foreach(var obj in objects)
        {
            var item = (ItemData)obj;
            _items.Add(item.Index, item);
        }
    }
    public ItemData TryGet(int index)
    {
        if(_items.ContainsKey(index))
            return _items[index];
        Debug.LogError($"Нет предмета {index}");
        return null;
    }
}

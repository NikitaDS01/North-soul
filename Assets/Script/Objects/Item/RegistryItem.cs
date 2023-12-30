using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RegistryItem
{
    private static Dictionary<int, ItemData> _items = new Dictionary<int, ItemData>();

    public static void Registry()
    {
        var objects = Resources.LoadAll("Items");
        foreach(var obj in objects)
        {
            var item = (ItemData)obj;
            _items.Add(item.Index, item);
        }
    }
    public static ItemData TryGet(int index)
    {
        if(_items.ContainsKey(index))
            return _items[index];
        Debug.LogError($"Нет предмета {index}");
        return null;
    }
}

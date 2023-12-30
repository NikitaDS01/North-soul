using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IEnumerable
{
    private ItemData[] _items;
    private int _maxCountItem;
    private int _currentEmptySlot;

    public Inventory(int maxCountItem)
    {
        _maxCountItem = maxCountItem;
        _currentEmptySlot = 0;
        _items = new ItemData[_maxCountItem];
    }
    public IReadOnlyList<ItemData> Items => _items;
    public int Count => _currentEmptySlot;
    public int MaxCount => _maxCountItem;
    public ItemData this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    public void Add(ItemData item)
    {
        if (this.IsTherePlace())
        {
            _items[_currentEmptySlot] = item;
            _currentEmptySlot++;
        }
        else
        {
            Debug.LogError($"Нет места для {item.Name}");
        }
    }
    public void Remove(ItemData item)
    {
        for(int index = 0;index < Count; index++)
        {
            if(_items[index] == item)
            {
                _items[index] = null;
                _currentEmptySlot--;
            }
        }
        Debug.LogError($"Предмет {item.Name} нет");
    }
    public bool IsTherePlace()
    {
        return Count != MaxCount;
    }
    public bool Contain(ItemData item)
    {
        for (int index = 0; index < Count; index++)
        {
            if (_items[index] == item)
            {
                return true;
            }
        }
        return false;
    }

    public IEnumerator GetEnumerator()
    {
        return _items.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

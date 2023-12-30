using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game/Item Data", order = 51)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private int _id = 0;
    [SerializeField]
    private string _name = string.Empty;
    [SerializeField, TextArea(5,2)]
    private string _description = string.Empty;
    [SerializeField]
    private Sprite _icon;

    public int Index => _id;
    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
    public override bool Equals(object other)
    {
        if ((other == null) || this.GetType().Equals(other.GetType()))
        {
            return false;
        }
        else
        {
            var item = (ItemData)other;
            return this._id == item._id;
        }
    }
    public static bool operator ==(ItemData a, ItemData b)
    {
        return a.Index == b.Index;
    }
    public static bool operator !=(ItemData a, ItemData b)
    {
        return a.Index != b.Index;
    }
}

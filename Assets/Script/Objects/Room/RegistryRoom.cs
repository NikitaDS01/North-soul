using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Регист всех комнат в игре
/// </summary>
public static class RegistryRoom
{
    private static Dictionary<int, Room> _listRoom = new Dictionary<int, Room>();

    public static void Clear() => _listRoom.Clear();

    public static void Add(Room roomIn) => _listRoom.Add(roomIn.Index, roomIn);

    public static Room? Find(Vector3 positionIn)
    {
        foreach (var room in _listRoom.Values)
        {
            bool valueX = room.LeftX <= positionIn.x && room.RightX >= positionIn.x;
            bool valueY = room.DownY <= positionIn.y && room.UpY >= positionIn.y;
            if (valueX)
                return room;
        }
        return null;
    }
}

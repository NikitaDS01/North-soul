using UnityEngine.Rendering.Universal;
using UnityEngine;

// Нужен для работы со светом.
/// <summary>
/// Класс представляет комнату
/// </summary>
public struct Room
{
    private static int _lastIndex = 1;

    public int Index { get; set; }
    public Vector2 PointLeftUp { get; set; }
    public Vector2 PointRightDown { get; set; }
    public Light2D Light { get; set; }

    public Room(Vector2 pointLeftUpIn, Vector2 pointRightDownIn, Light2D lightIn)
    {
        Index = _lastIndex;
        PointLeftUp = pointLeftUpIn;
        PointRightDown = pointRightDownIn;
        Light = lightIn;

        RegistryRoom.Add(this);
        _lastIndex++;
    }
    public float LeftX => PointLeftUp.x;
    public float RightX => PointRightDown.x;
    public float UpY => PointLeftUp.y;
    public float DownY => PointRightDown.y;
}

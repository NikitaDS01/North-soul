using UnityEngine;

public class TravelPlayerSignal
{
    private Vector2 _newPosition;
    public TravelPlayerSignal(Vector2 newPosition)
    {
        _newPosition = newPosition;
    }
    public Vector2 NewPosition => _newPosition;
}
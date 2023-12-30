using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Данный класс нужен для указания комнаты в Unity. В итоге он удаляется
/// </summary>
public class UnityRoom : MonoBehaviour
{
    [SerializeField]
    private Vector2 _pointLeftUp;
    [SerializeField]
    private Vector2 _pointRightDown;
    [SerializeField]
    private Light2D _light;

    private void Start()
    {
        var room = new Room(_pointLeftUp, _pointRightDown, _light);

        Destroy(this);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 size = new Vector3(
            Mathf.Abs(_pointRightDown.x - _pointLeftUp.x),
            Mathf.Abs(_pointLeftUp.y - _pointRightDown.y)
            );
        Vector3 center = new Vector3(
            (_pointRightDown.x + _pointLeftUp.x)/2,
            (_pointRightDown.y + _pointLeftUp.y)/2
            );
        Gizmos.DrawWireCube(center, size);
    }
}

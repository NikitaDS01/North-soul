using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform _player;

    private bool _isHide = false;
    private Transform _transform;

    private void Start()
    {
        _player = GameCore.PlayerSingleton.transform;
        _transform = transform;
    }
    private void Update()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, 
            new Vector2(_player.position.x, _transform.position.y), Time.deltaTime);
    }
    private void LateUpdate()
    {
        Room? room = RegistryRoom.Find(_transform.position);
        if(room != null)
        {
            // ≈сли сделать !room.Value.Light.enabled, то враг будет при свете по€вл€етс€
            if (room.Value.Light.enabled)
            {
                Hide();
            }
            else
            {
                Show();
            }
            
        }
        else
        {
            Hide();
        }
    }
    private void Hide()
    {
        if (!_isHide)
        {
            _transform.Rotate(0, 90, 0);
            _isHide = true;
        }
    }
    private void Show()
    {
        if (_isHide)
        {
            _transform.Rotate(0, -90, 0);
            _isHide = false;
        }
    }
}

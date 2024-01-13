using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform _player;
    private RegistryLight _lights;
    private bool _isHide = false;
    private Transform _transform;

    private void Start()
    {
        var playerObject = ServiceLocator.Singleton.Get<Player>();
        _lights = ServiceLocator.Singleton.Get<RegistryLight>();
        _player = playerObject.transform;
        _transform = transform;
    }
    private void Update()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, 
            new Vector2(_player.position.x, _transform.position.y), Time.deltaTime);
    }
    private void LateUpdate()
    {
        var data = _lights.Find(_transform.position);
        if(data != null)
        {
            Change(!data.Light.enabled);
        }
        else
        {
            Hide();
        }
    }
    private void Change(bool isHideIn)
    {
        if (isHideIn)
            Show();
        else
            Hide();
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

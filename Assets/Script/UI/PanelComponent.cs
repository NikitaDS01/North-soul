using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Данный класс хранит все элементы Canvas, которые необходимо менять
/// </summary>
public class PanelComponent : MonoBehaviour
{
    private const float RADUIS_SPHERE = 0.2f;

    [Header("Текстовый часть")]
    [SerializeField] private Image _fonText;
    [SerializeField] private Text _text;
    [Header("Инвентарь")]
    [SerializeField] private GameObject _inventoryViewObject;
    [SerializeField] private Image[] _images;
    [Header("Меню")]
    [SerializeField] private GameObject _menu;
    [Header("Камера")]
    [SerializeField] private Transform _currentCamera;
    [SerializeField] private float _dumping = 1.5f;
    [Header("Остальное")]
    [SerializeField] private Image _blackFon;

    private InventoryView _inventoryView;
    private TextView _textView;
    private CameraWork _camera;
    private MenuView _menuView;
    private bool _isMenuAction;

    public TextView TextView => _textView;

    private void Start()
    {
        _textView = new TextView(_fonText, _text);
        _inventoryView = new InventoryView(_inventoryViewObject, _images);
        _menuView = new MenuView(_menu);
        _camera = new CameraWork(_currentCamera, _dumping);
        _isMenuAction = false;
        this.MenuOff();
    }
    private void LateUpdate()
    {
        _camera.Follow(GameCore.PlayerObjectSingleton.transform);
        if (Input.GetKeyUp(Settings.KeyEcs))
        {
            if (_isMenuAction)
            {
                MenuOff();
                _isMenuAction = false;
            }
            else
            {
                MenuOn();
                _isMenuAction = true;
            }
        }
    }    

    public void MenuOn()
    {
        Time.timeScale = 0f;
        _menuView.ViewOn();
        _inventoryView.ViewOn();
    }
    public void MenuOff()
    {
        Time.timeScale = 1f;
        _menuView.ViewOff();
        _inventoryView.ViewOff();
    }
    public void ForcedTPCameraToPlayer()
    {
        _camera.ForcedFollow(GameCore.PlayerObjectSingleton.transform);
    }
    public IEnumerator TransitionOn(float second, float speed)
    {
        while(_blackFon.color.a != 1)
        {
            var color = _blackFon.color;
            color.a += speed;
            _blackFon.color = color;
            yield return new WaitForSeconds(second);
        }
    }
    public IEnumerator TransitionOff(float second, float speed)
    {
        while (_blackFon.color.a != 0)
        {
            var color = _blackFon.color;
            color.a -= speed;
            _blackFon.color = color;
            yield return new WaitForSeconds(second);
        }
    }

}

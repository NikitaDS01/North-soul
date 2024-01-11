using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Данный класс хранит все элементы Canvas, которые необходимо менять
/// </summary>
public class PanelComponent : MonoBehaviour, IService
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
    [SerializeField] private Vector2 _offset;
    [SerializeField] private float _dumping = 1.5f;
    [Header("Остальное")]
    [SerializeField] private Image _blackFon;

    private InventoryView _inventoryView;
    private BlackoutView _blackout;
    private TextView _textView;
    private CameraWork _camera;
    private MenuButtonView _menuView;
    private bool _isMenuAction;

    public TextView TextView => _textView;

    private void Start()
    {
        _textView = new TextView(_fonText, _text);
        _inventoryView = new InventoryView(_inventoryViewObject, _images);
        _camera = new CameraWork(_currentCamera, _dumping, _offset);
        _blackout = new BlackoutView(_blackFon);
        _menuView = new MenuButtonView(_menu);
        _isMenuAction = false;
        this.MenuOff();
    }
    private void LateUpdate()
    {
        if(GameController.Player.IsActive)
            _camera.Follow(GameController.PlayerObject.transform);
        if (Input.GetKeyUp(Settings.KeyEcs) && GameController.IsActiveGame)
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
        GameController.ChangeActiveGame(false);
        _menuView.ViewOn();
        _inventoryView.ViewOn();
    }
    public void MenuOff()
    {
        GameController.ChangeActiveGame(true);
        _menuView.ViewOff();
        _inventoryView.ViewOff();
    }
}

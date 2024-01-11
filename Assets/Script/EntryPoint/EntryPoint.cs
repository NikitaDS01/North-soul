using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private CoritunaService _coritunaService;
    [SerializeField] private GameController _gameCore;
    [SerializeField] private Player _player;
    [Header("UI - элементы")]
    [SerializeField] private BlackoutView _blackoutView;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private SettingsVIew _settingView;
    [SerializeField] private MenuButtonView _menuView;
    [SerializeField] private TextView _textView;
    [SerializeField] private CameraWork _camera;

    private CompletedActions _completedaAtions;
    private RegistryItem _registryItem;
    private EventBus _eventBus;

    private void Awake()
    {
        _eventBus = new EventBus(false);
        _registryItem = new RegistryItem();
        _completedaAtions = new CompletedActions();

        Registry();
        Init();
    }

    private void Registry()
    {
        ServiceLocator.Init();

        ServiceLocator.Singleton.Register(_eventBus);
        ServiceLocator.Singleton.Register(_registryItem);
        ServiceLocator.Singleton.Register(_completedaAtions);
        ServiceLocator.Singleton.Register(_gameCore);
        ServiceLocator.Singleton.Register(_coritunaService);
        ServiceLocator.Singleton.Register(_player);
        ServiceLocator.Singleton.Register(_inventoryView);
        ServiceLocator.Singleton.Register(_settingView);
        ServiceLocator.Singleton.Register(_menuView);
        ServiceLocator.Singleton.Register(_textView);
        ServiceLocator.Singleton.Register(_camera);
    }

    private void Init()
    {
        _registryItem.LoadFromFile();
    }
}

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GlobalLight _globalLight;
    [SerializeField] private Player _player;
    [Header("UI - элементы")]
    [SerializeField] private BlackoutView _blackoutView;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private SettingsVIew _settingView;
    [SerializeField] private MenuButtonView _menuView;
    [SerializeField] private TextView _textView;
    [SerializeField] private CameraWork _camera;

    private UIController _UIController;
    private CompletedActions _completedAtions;
    private CoritunaService _coritunaService;
    private GameController _gameCore;
    private RegistryItem _registryItem;
    private RegistryLight _registryLight;
    private EventBus _eventBus;
    

    private List<IContainEvent> _containEvents;

    private void Awake()
    {
        _containEvents = new List<IContainEvent>();

        _coritunaService = this.AddComponent<CoritunaService>();
        _UIController = this.AddComponent<UIController>();

        _eventBus = new EventBus(false);
        _gameCore = new GameController();
        _registryItem = new RegistryItem();
        _registryLight = new RegistryLight();
        _completedAtions = new CompletedActions();

        Registry();
        Init();
        Enable();
    }
    private void OnDestroy()
    {
        Disposable();
    }
    
    private void Registry()
    {
        ServiceLocator.Init();

        ServiceLocator.Singleton.Register(_eventBus);
        ServiceLocator.Singleton.Register(_registryItem);
        ServiceLocator.Singleton.Register(_registryLight);
        ServiceLocator.Singleton.Register(_globalLight);
        ServiceLocator.Singleton.Register(_completedAtions);
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
        _gameCore.Init();
        _UIController.Init();
        _inventoryView.Init();
        _menuView.Init();
        _textView.Init();
        _registryItem.Init();
        _registryLight.Init();
        _player.Init();
        _completedAtions.Init();

        _containEvents.Add(_gameCore);
        _containEvents.Add(_UIController);
        _containEvents.Add(_inventoryView);
        _containEvents.Add(_menuView);
        _containEvents.Add(_textView);
        _containEvents.Add(_player);
        _containEvents.Add(_completedAtions);
    }
    private void Enable()
    {
        foreach (var item in _containEvents)
            item.EnableEvent();
    }
    private void Disposable()
    {
        foreach (var item in _containEvents)
            item.DisableEvent();
    }
}

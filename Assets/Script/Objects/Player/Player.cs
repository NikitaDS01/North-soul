using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IService, IContainEvent
{
    [Header("Скорость")]
    [SerializeField, Min(0)] private float _speed;
    [Header("Анимация")]
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Header("Инвентарь")]
    [SerializeField] private int _countItem = 6;
    [Header("Свет")]
    [SerializeField, Min(0)] private float _speedBlackout = 1; 
    [SerializeField, Min(0)] private float _speedShine = 1; 

    private EventBus _eventBus;
    private RegistryLight _lights;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private Inventory _inventory;
    private EyesPlayer _eyes;
    private Animation _animation;
    private Move _move;

    private bool _canMove = true;
    private bool _isShow = true;

    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _eyes = new EyesPlayer(_speedBlackout, _speedShine);
        _animation = new Animation(_animator);
        _move = new Move(_rigidbody, transform);
        _inventory = new Inventory(_countItem);

        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
        _lights = ServiceLocator.Singleton.Get<RegistryLight>();
    }
    public Inventory Inventory => _inventory;
    public bool IsActive => _canMove;
    public bool IsShow => _isShow;

    private void Update()
    {
        if (!_canMove)
            return;

        _animation.Run();
    }
    private void FixedUpdate()
    {
        if (!_canMove)
            return;

        _move.Run(_speed);
    }
    private void LateUpdate()
    {
        _eyes.Run();
        
        var data = _lights.Find(_transform.position);
        if (data == null)
            _eyes.ChangeLight(true);
        else
            _eyes.ChangeLight(data.Light.enabled);        
    }
    private void OnDestroy()
    {
        DisableEvent();
    }
    private void AddItem(AddItemInventorySignal signalIn)
    {
        _inventory.Add(signalIn.Item);
    }
    private void StartMove(StartGameSignal signal)
    {
        _canMove = true;
    }
    private void StopMove(StopGameSignal signal)
    {
        _animation.Stop();
        _rigidbody.velocity = Vector2.zero;
        _canMove = false;
    }
    public void TravelPlayer(TravelPlayerSignal signal)
    {
        _transform.position = signal.NewPosition;
    }
    public void EnableEvent()
    {
        _eventBus.Subscribe<AddItemInventorySignal>(AddItem);
        _eventBus.Subscribe<StartGameSignal>(StartMove);
        _eventBus.Subscribe<StopGameSignal>(StopMove);
        _eventBus.Subscribe<TravelPlayerSignal>(TravelPlayer);
    }
    public void DisableEvent()
    {
        _eventBus.Unsubcribe<AddItemInventorySignal>(AddItem);
        _eventBus.Unsubcribe<StartGameSignal>(StartMove);
        _eventBus.Unsubcribe<StopGameSignal>(StopMove);
        _eventBus.Unsubcribe<TravelPlayerSignal>(TravelPlayer);
    }
}

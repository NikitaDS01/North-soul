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

    private EventBus _eventBus;
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
        _animation = new Animation(_animator);
        _move = new Move(_rigidbody, transform);
        _inventory = new Inventory(_countItem);
        _eyes = new EyesPlayer();

        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
        EnableEvent();
    }
    public Inventory Inventory => _inventory;
    public bool IsActive => _canMove;
    public bool IsShow => _isShow;

    private void Update()
    {
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

    }
    private void OnDestroy()
    {
        DisableEvent();
    }
    private void AddItem(AddItemInventorySignal signalIn)
    {
        _inventory.Add(signalIn.Item);
    }
    public void EnableEvent()
    {
        _eventBus.Subscribe<AddItemInventorySignal>(AddItem);
    }
    public void DisableEvent()
    {
        _eventBus.Unsubcribe<AddItemInventorySignal>(AddItem);
    }
}

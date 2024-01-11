using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IService
{
    [Header("Скорость")]
    [SerializeField, Min(0)] private float _speed;
    [Header("Анимация")]
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Header("Инвентарь")]
    [SerializeField] private int _countItem = 6;

    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Inventory _inventory;
    private EyesPlayer _eyes;
    private Animation _animation;
    private Move _move;
    private bool _isActive;
    private bool _isShow;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();

        _isActive = true;
        _isShow = true;
        _animation = new Animation(_animator);
        _move = new Move(_rigidbody, transform);
        _inventory = new Inventory(_countItem);
        _eyes = new EyesPlayer();
    }
    public Inventory Inventory => _inventory;
    public bool IsActive => _isActive;
    public bool IsShow => _isShow;
    public void SetActive(bool isActive)
    {
        _rigidbody.velocity = Vector2.zero;
        _isActive = isActive;
    }
    public void SetShow(bool showIn)
    {
        _isShow = showIn;
        _spriteRenderer.enabled = showIn;
    }

    private void Update()
    {
        _animation.Run();
    }
    private void FixedUpdate()
    {
        if (_isActive)
            _move.Run(_speed);
    }
    private void LateUpdate()
    {

    }
}

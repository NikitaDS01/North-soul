using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Скорость")]
    [SerializeField, Min(0)] private float _speed;
    [Header("Анимация")]
    [SerializeField] private Animator _animator;
    [Header("Инвентарь")]
    [SerializeField] private int _countItem = 6;

    private Inventory _inventory;
    private Animation _animation;
    private Move _move;

    private void Start()
    {
        var rb = GetComponent<Rigidbody2D>();

        _animation = new Animation(_animator);
        _move = new Move(rb, transform);
        _inventory = new Inventory(_countItem);
    }
    public Inventory Inventory => _inventory;

    private void Update()
    {
        _animation.Run();
    }
    private void FixedUpdate()
    {
        _move.Run(_speed);
    }
}

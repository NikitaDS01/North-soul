using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
    public enum TypeCriterion
    {
        None = -1,
        PresentItem = 1,
        DoneAction = 2
    }
    [SerializeField] private bool _isButton = false;
    [SerializeField] private bool _isLoop = false;
    [SerializeField] private string _tag = "Player";
    // Все события, которые должны произойти
    [SerializeField] private UnityEvent<GameEventArgs> _onWorkTrigger; 

    private bool _isWorkTrigger = false; // Он активировался или нет
    private Collider2D _collider;
    private GameObject _object;

    public bool IsEmptyObject => _object == null;
    public GameObject Gameobject => _object;

    private void Awake()
    {
        _object = null;
        _collider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_tag))
            _object = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_tag))
            _object = null;
    }
    private void LateUpdate()
    {
        if (!_isWorkTrigger && !IsEmptyObject)
        {
            if (_isButton)
                if (!Input.GetKeyUp(Settings.KeyUse))
                    return;

            _onWorkTrigger?.Invoke(new GameEventArgs { Object = _object });

            if (!_isLoop)
                _isWorkTrigger = true;
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
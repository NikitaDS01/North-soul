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
    [Header("Настройки")]
    [SerializeField] private bool _isButton = false;
    [SerializeField] private bool _isLoop = false;
    [SerializeField] private string _tag = "Player";
    [Header("Условия")]
    [SerializeField] private TypeCriterion _typeCriterion = TypeCriterion.None;
    [SerializeField] private string _nameAction;
    [SerializeField] private ItemData _item;
    [SerializeField] private UnityEvent<GameEventArgs> _onNotWorkTrigger;
    [Header("События при срабатывание")]
    [SerializeField] private UnityEvent<GameEventArgs> _onWorkTrigger; 

    private Collider2D _collider;
    private GameObject _object;
    private ITriggerCriterion _triggerCriterion;

    public bool IsEmptyObject => _object == null;
    public GameObject Gameobject => _object;

    private void Start()
    {
        _object = null;
        _collider = GetComponent<Collider2D>();
        switch (_typeCriterion)
        {
            case TypeCriterion.None: 
                _triggerCriterion = new CritetionNone(); break;
            case TypeCriterion.PresentItem: 
                _triggerCriterion = new CriterionPresentItem(_item); break;
            case TypeCriterion.DoneAction: 
                _triggerCriterion = new CriterionDoneAction(_nameAction); break;
        }
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
        if (!IsEmptyObject)
        {
            if (_isButton)
                if (!Input.GetKeyUp(Settings.KeyUse))
                    return;

            var args = new GameEventArgs { Object = _object };
            if (_triggerCriterion.Check())
            {
                _onWorkTrigger?.Invoke(args);
                if (!_isLoop)
                    Destroy(this);
            }
            else
            {
                _onNotWorkTrigger?.Invoke(args);
            }
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
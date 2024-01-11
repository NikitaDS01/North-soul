using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Trigger : MonoBehaviour
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

    private ITriggerCriterion _triggerCriterion;
    protected EventBus eventBus;
    private Collider2D _collider;
    private GameObject _object;

    protected bool IsEmptyObject => _object == null;
    protected GameObject Gameobject => _object;

    private void Start()
    {
        _object = null;
        _collider = GetComponent<Collider2D>();
        eventBus = ServiceLocator.Singleton.Get<EventBus>();
        switch (_typeCriterion)
        {
            case TypeCriterion.None:
                _triggerCriterion = new CritetionNone(); break;
            case TypeCriterion.PresentItem:
                _triggerCriterion = new CriterionPresentItem(_item); break;
            case TypeCriterion.DoneAction:
                _triggerCriterion = new CriterionDoneAction(_nameAction); break;
        }
        InputData();
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
        if (IsEmptyObject)
            return;

        if (_isButton)
            if (!Input.GetKeyUp(Settings.KeyUse))
                return;

        if (_triggerCriterion.Check() && Condition())
        {
            Work();
            if (!_isLoop)
                Destroy(this);
        }
        else
        {
            NotWork();
        }
    }
    /// <summary>
    /// Действие триггера, если сработали условия
    /// </summary>
    protected abstract void Work();
    /// <summary>
    /// Метод для ввода других данных
    /// </summary>
    protected virtual void InputData()
    {
        return;
    }
    /// <summary>
    /// Условие для триггера
    /// </summary>
    /// <returns>Выполнилось ли условие</returns>
    protected virtual bool Condition()
    {
        return true;
    }
    /// <summary>
    /// Действия триггера, если не сработали условия.
    /// </summary>
    protected virtual void NotWork()
    {
        return;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
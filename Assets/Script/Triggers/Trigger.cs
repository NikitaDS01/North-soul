using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private bool _isButton = false;
    [SerializeField] private bool _isLoop = false;
    [SerializeField] private string _tag = "Player";

    private List<IInteractable> _workTrigger;
    private List<INotInteractable> _notWorkTrigger;
    private List<IConditionInteractable> _conditionTrigger;
    private Collider2D _collider;
    private GameObject _object;
    private EventBus _eventBus;

    protected bool IsEmptyObject => _object == null;
    protected GameObject Gameobject => _object;

    private void Start()
    {
        _object = null;
        _collider = GetComponent<Collider2D>();
        _eventBus = ServiceLocator.Singleton.Get<EventBus>();

        _workTrigger = new List<IInteractable>();
        _notWorkTrigger = new List<INotInteractable>();
        _conditionTrigger = new List<IConditionInteractable>();

        this.GetComponents(_workTrigger);
        this.GetComponents(_notWorkTrigger);
        this.GetComponents(_conditionTrigger);
        Debug.Log($"{_workTrigger.Count} {_notWorkTrigger.Count} {_conditionTrigger.Count}");
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

        if (Condition())
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
    private bool Condition()
    {
        foreach(var condition in _conditionTrigger)
        {
            if(!condition.Check()) 
                return false;
        }
        return true;
    }
    private void Work()
    {
        foreach(var item in _workTrigger)
        {
            item.Work(_eventBus);
        }
    }
    private void NotWork()
    {
        foreach (var item in _notWorkTrigger)
        {
            item.NotWork(_eventBus);
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
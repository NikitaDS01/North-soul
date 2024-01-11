using System.Collections;
using UnityEngine;

public class Ladder : AbstractAction
{
    private static float _speedBlackFon = 0.8f;
    public enum TypeWork
    {
        None = -1,
        OnObject = 1,
        OnPosition = 2
    }

    [SerializeField] private TypeWork _typeWork = TypeWork.None;
    [SerializeField] private Vector2 _targetPosition;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private GameObject _targetObject;

    public override void Run(GameEventArgs args)
    {
        var player = args.Object;
        StartCoroutine(GameController.Panel.ActineBlackFon(_speedBlackFon));
        StartCoroutine(GameController.Panel.CorutinaCameraToPlayer(_speedBlackFon + 1f));
        StartCoroutine(GameController.DeactivatePlayer(_speedBlackFon * 2 + 1f));
        switch (_typeWork)
        {
            case TypeWork.OnObject: 
                player.transform.position = 
                    (Vector2)_targetObject.transform.position + _offset; break;
            case TypeWork.OnPosition: 
                player.transform.position = _targetPosition; break;
            default: Debug.LogError("Нужно выбрать режим для двери"); break;
        }
        
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        switch (_typeWork)
        {
            case TypeWork.OnObject:
                Gizmos.DrawSphere(
                    (Vector2)_targetObject.transform.position + _offset, 0.2f); break;
            case TypeWork.OnPosition:
                Gizmos.DrawSphere(_targetPosition, 0.2f); break;
            default: Debug.LogError("Нужно выбрать режим для двери"); break;
        }
    }
}

using UnityEngine;

public class Ladder : AbstractAction
{
    private static float _second = 1f;
    private static float _speed = 0.05f;
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
        StartCoroutine(GameCore.PanelSingleton.TransitionOn(_second, _speed));

        switch (_typeWork)
        {
            case TypeWork.OnObject: 
                player.transform.position = 
                    (Vector2)_targetObject.transform.position + _offset; break;
            case TypeWork.OnPosition: 
                player.transform.position = _targetPosition; break;
            default: Debug.LogError("Нужно выбрать режим для двери"); break;
        }

        StartCoroutine(GameCore.PanelSingleton.TransitionOff(_second, _speed));
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
    private void Update()
    {

    }
}

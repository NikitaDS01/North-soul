using UnityEngine;

public class LadderInteractable : MonoBehaviour, IInteractable
{
    private const float RADUIS_SPHERE = 0.2f;

    [SerializeField] private Vector2 _offset;
    [SerializeField] private Transform _targetTransform;
    private Transform _playerTransform;

    private void Start()
    {
        var player = ServiceLocator.Singleton.Get<Player>();
        _playerTransform = player.transform;
    }

    public void Work(EventBus eventBusIn)
    {
        var signal = new TravelPlayerSignal(
            (Vector2)_targetTransform.position + _offset);
        eventBusIn.Invoke(signal);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(
            (Vector2)_targetTransform.position + _offset, RADUIS_SPHERE);
    }
}

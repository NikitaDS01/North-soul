using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Light2D _light;

    public void Work(EventBus eventBusIn)
    {
        _light.enabled = !_light.enabled;
    }
}

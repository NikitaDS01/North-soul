using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Данный класс нужен для работы со светом, при нажатие/ подходе игрока.
/// </summary>
public class WorkLight : AbstractAction
{
    /// <summary>
    /// Как свет должен работать
    /// </summary>
    public enum WorkTypeLight
    {
        None = -1,
        Standart = 1,
        DuringTime = 2
    }

    [SerializeField] private WorkTypeLight _workTypeLight = WorkTypeLight.None;
    [SerializeField] private Light2D _light;
    [SerializeField, Min(0)] private float _period;
    
    private ILigthWork _lightWork;

    private void Start()
    {
        switch (_workTypeLight)
        {
            case WorkTypeLight.Standart: _lightWork = new LightWorkStandart(); break;
            case WorkTypeLight.DuringTime: _lightWork = new LightWorkTime(_period); break;
            default: Debug.LogError("Нужно выбрать режим для лампы"); break;
        }
    }

    public override void Run(GameEventArgs args)
    {
        _lightWork.Work(_light);
    }
    private void Update()
    {
        
    }
}

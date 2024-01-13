/// <summary>
/// Класс, который является ядром игры
/// </summary>
public class GameController : IService, IContainEvent
{
    private EventBus _eventBus;
    private bool _isActiveGame;

    public void DisableEvent()
    {
        _eventBus.Unsubcribe<EnableMenuSignal>(EnableMenu);
        _eventBus.Unsubcribe<DisableMenuSignal>(DisableMenu);
    }
    public void EnableEvent()
    {
        _eventBus.Subscribe<EnableMenuSignal>(EnableMenu);
        _eventBus.Subscribe<DisableMenuSignal>(DisableMenu);
    }
    public void Init()
    {
        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
    }

    public void StartGame()
    {
        var signal = new StartGameSignal();
        _eventBus.Invoke<StartGameSignal>(signal);
    }
    public void StopGame()
    {
        var signal = new StopGameSignal();
        _eventBus.Invoke<StopGameSignal>(signal);
    }
    public void EnableMenu(EnableMenuSignal signal) => StopGame();
    public void DisableMenu(DisableMenuSignal signal) => StartGame();
}
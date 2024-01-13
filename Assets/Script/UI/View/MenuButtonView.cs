using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MenuButtonView : IService, IContainEvent
{
    [SerializeField] private GameObject _menuObject;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _ExitButton;
    private EventBus _eventBus;

    public void ViewOn()
    {
        _menuObject.SetActive(true);
    }
    public void ViewOff()
    {
        _menuObject.SetActive(false);
    }
    public void Init()
    {
        _eventBus = ServiceLocator.Singleton.Get<EventBus>();

        _playButton.onClick.AddListener(PlayButton);
        _settingButton.onClick.AddListener(SettingButton);
        _ExitButton.onClick.AddListener(ExitButton);
        Debug.Log("Кнопки загрузились");
    }
    public void EnableEvent()
    {
        _eventBus.Subscribe<EnableMenuSignal>(Enable);
        _eventBus.Subscribe<DisableMenuSignal>(Disable);
    }
    public void DisableEvent()
    {
        _eventBus.Unsubcribe<EnableMenuSignal>(Enable);
        _eventBus.Unsubcribe<DisableMenuSignal>(Disable);
    }
    public void Enable(EnableMenuSignal signal) => ViewOn();
    public void Disable(DisableMenuSignal signal) => ViewOff();

    public void PlayButton()
    {
        _eventBus.Invoke(new DisableMenuSignal());
    }
    public void SettingButton()
    {
        Debug.Log("Настройки");
    }
    public void ExitButton()
    {
        Debug.Log("Выход из игры");
        Application.Quit();
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextView : IService, IContainEvent
{
    private const float SPEED_READ = 8f;
    private static float _minSecond = 3f;

    [SerializeField] private Image _fonText;
    [SerializeField] private Text _text;
    
    private CoritunaService _coritunaService;
    private EventBus _eventBus;

    public void DisableEvent()
    {
        _eventBus.Unsubcribe<AddItemInventorySignal>(PrintAddItem);
        _eventBus.Unsubcribe<NotPlaceInventorySignal>(PrintNotAddItem);
    }

    public void EnableEvent()
    {
        _eventBus.Subscribe<AddItemInventorySignal>(PrintAddItem);
        _eventBus.Subscribe<NotPlaceInventorySignal>(PrintNotAddItem);
    }

    public void Init()
    {
        _coritunaService = ServiceLocator.Singleton.Get<CoritunaService>();

        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
    }

    public IEnumerator PrintText(string textIn)
    {
        this.SetAction(true);
        do
        {
            float second = textIn.Length / SPEED_READ;
            _text.text = textIn;
            yield return new WaitForSeconds(Mathf.Max(second, _minSecond));
        } while (false);

        this.SetAction(false);
    }
    public IEnumerator PrintText(DialogData dataIn)
    {
        this.SetAction(true);
        var textData = dataIn;
        while (textData != null)
        {
            float second = textData.Text.Length / SPEED_READ;
            _text.text = textData.Text;
            yield return new WaitForSeconds(Mathf.Max(second, _minSecond));
            textData = textData.NextText;
        } 

        this.SetAction(false);
    }
    private void SetAction(bool isActionIn)
    {
        _fonText.enabled = isActionIn;
        _text.enabled = isActionIn;
    }
    private void PrintAddItem(AddItemInventorySignal signal)
    {
        var text = $"Вы нашли предмет - {signal.Item.Name}";
        _coritunaService.StartCoroutine(PrintText(text));
    }
    private void PrintNotAddItem(NotPlaceInventorySignal signal)
    {
        var text = $"Ваш инвентарь заполнен";
        _coritunaService.StartCoroutine(PrintText(text));
    }
}

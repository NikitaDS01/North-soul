using System.Linq;
using UnityEngine;

/// <summary>
/// Класс, который является ядром игры
/// </summary>
[RequireComponent(typeof(PanelComponent))]
public class GameCore : MonoBehaviour
{
    private static PanelComponent _panel = null!;
    private static GameObject _playerObject = null!;
    private static CompletedActions _completedAction = null!;
    private static DialogData[] _dialogDatas;

    [Header("Игрок")]
    [SerializeField] private GameObject _player;
    [Header("Все диалоги")]
    [SerializeField] private DialogData[] _dialogsCurrentLevel;

    private void Awake()
    {
        _completedAction = new CompletedActions();
        _playerObject = _player;
        _dialogDatas = _dialogsCurrentLevel;
        _panel = GetComponent<PanelComponent>();

        RegistryItem.Registry();
    }

    public static PanelComponent PanelSingleton => _panel;
    public static GameObject PlayerObjectSingleton => _playerObject;
    public static Player PlayerSingleton => _playerObject.GetComponent<Player>();

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Выход");
    }

    public static void AddAction(string actionNameIn) =>
        _completedAction.Add(actionNameIn);
    public static bool ContainAction(string actionNameIn) =>
        _completedAction.Contain(actionNameIn);
    public static DialogData GetDialog(string dialogNameIn) =>
        _dialogDatas.FirstOrDefault(dialog => dialog.Name == dialogNameIn);
}
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Класс, который является ядром игры
/// </summary>

public class GameController : MonoBehaviour, IService
{
    private EventBus _eventBus;


    //public static void ChangeActiveGame(bool activeIn)
    //{
    //    GameController.Singleton._isActiveGame = activeIn;
    //    Time.timeScale = activeIn ? 1.0f : 0.0f;
    //    EventGame.InvokeChangeActiveGame();
    //}
    //public static void AddAction(string actionNameIn) =>
    //    GameController.Singleton._completedAction.Add(actionNameIn);
    //public static bool ContainAction(string actionNameIn) =>
    //    GameController.Singleton._completedAction.Contain(actionNameIn);
    //public static DialogData TryGetDialog(string dialogNameIn) =>
    //    GameController.Singleton._dialogsCurrentLevel.FirstOrDefault(dialog => dialog.Name == dialogNameIn);
    //public static IEnumerator DeactivatePlayer(float secondIn)
    //{
    //    var player = GameController.Player;
    //    ChangeActiveGame(false);
    //    player.SetActive(false);
    //    player.SetShow(false);

    //    yield return new WaitForSecondsRealtime(secondIn);

    //    player.SetActive(true);
    //    player.SetShow(true);
    //    ChangeActiveGame(true);
    //}
    //public void Exit()
    //{
    //    Application.Quit();
    //    Debug.Log("Выход");
    //}
}
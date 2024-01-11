using System;

public static class EventGame
{
    public static event Action OnChangeActiveGame;
    public static event Action OnDeadPlayer;
    public static event Action OnEnableMenu;

    public static void InvokeChangeActiveGame() => OnChangeActiveGame?.Invoke();
    public static void InvokeEnableMenu() => OnEnableMenu?.Invoke();

    public static void InvokeDeadPlayer() => OnDeadPlayer?.Invoke();
}
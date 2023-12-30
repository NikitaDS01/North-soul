﻿using UnityEngine;

/// <summary>
/// Класс, который является ядром игры
/// </summary>
[RequireComponent(typeof(PanelComponent))]
public class GameCore : MonoBehaviour
{
    private static PanelComponent _panelSingleton = null!;
    private static GameObject _playerSingleton = null!;
    private static CompletedActions _completedActionSingleton = null!;

    [SerializeField] private GameObject _player;

    private void Start()
    {
        _completedActionSingleton = new CompletedActions();
        _playerSingleton = _player;
        _panelSingleton = GetComponent<PanelComponent>();

        RegistryItem.Registry();
    }

    public static PanelComponent PanelSingleton => _panelSingleton;
    public static GameObject PlayerObjectSingleton => _playerSingleton;
    public static CompletedActions CompletedActionSingleton => _completedActionSingleton;
    public static Player PlayerSingleton => _playerSingleton.GetComponent<Player>();

}
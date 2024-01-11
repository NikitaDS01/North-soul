using UnityEngine.Rendering.Universal;
using UnityEngine;

[System.Serializable]
public class GameSetting
{
    [Header("Свет")]
    public Light2D light;
    [Range(0, 255)] public int maxLight;
    [Range(0, 255)] public int minLight;
    [Header("Все диалоги")]
    public DialogData[] dialogsCurrentLevel;
}

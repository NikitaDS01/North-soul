using UnityEngine.Rendering.Universal;
using UnityEngine;

[System.Serializable]
public class GlobalLight : IService
{
    [SerializeField] private Light2D _light;
    [SerializeField] private Color _brightColor;
    public GlobalLight(Light2D light)
    {
        _light = light;
    }
    public Light2D Light => _light;
    public Color BrightColor => _brightColor;
    public Color BlackColor => new Color(0, 0, 0);
}
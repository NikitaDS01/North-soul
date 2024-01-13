using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightData
{
    private Light2D _light;
    private Vector2 _centerPosition;
    private float _raduis;

    public LightData(Light2D light)
    {
        _light = light;
        _centerPosition = light.transform.position;
        _raduis = _light.pointLightOuterRadius;
    }
    public Light2D Light => _light;
    public Vector2 Center => _centerPosition;
    public float Raduis => _raduis; 
}
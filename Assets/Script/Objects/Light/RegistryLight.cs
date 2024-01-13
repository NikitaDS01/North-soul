using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RegistryLight : IService
{
    private const float OFFSET_RADIUS = 0.5f;
    private List<LightData> _lightDatas;

    public RegistryLight()
    {
        _lightDatas = new List<LightData>();
    } 
    public void Init()
    {
        this.LoadFromScene();
    }
    public void LoadFromScene()
    {
        var lights = GameObject.FindObjectsOfType<Light2D>();
        Debug.Log(lights.Length);
        foreach (var light in lights)
        {
            if (light.GetComponent<NotSaveLight>() != null)
                continue;

            var data = new LightData(light);
            _lightDatas.Add(data);
        }
        Debug.Log(_lightDatas.Count);
    }
    public LightData? Find(Vector2 position)
    {
        foreach (var light in _lightDatas)
        {
            float distance = Vector2.Distance(light.Center, position);
            if (distance < light.Raduis + OFFSET_RADIUS)
            {
                return light;
            }
        }
        return null;
    }
}
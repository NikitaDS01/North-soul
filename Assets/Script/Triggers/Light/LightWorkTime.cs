using System.Collections;
using UnityEngine.Rendering.Universal;
/// <summary>
/// В течение времени
/// </summary>
public class LightWorkTime : ILigthWork
{
    private float _period;
    public LightWorkTime(float period)
    {
        _period = period;
    }
    public void Work(Light2D light)
    {
        light.enabled = true;
    }
}

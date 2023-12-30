using UnityEngine.Rendering.Universal;
/// <summary>
/// При прикосновение
/// </summary>
public class LightWorkStandart : ILigthWork
{
    public void Work(Light2D light)
    {
        light.enabled = !light.enabled;
    }
}

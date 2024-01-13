using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EyesPlayer
{
    private bool _isLight;
    private float _degree;
    private float _speedBlackout;
    private float _speedShine;

    private GlobalLight _globalLight;
    
    public EyesPlayer(float speedBlackoutIn, float speedShineIn)
    {
        _globalLight = ServiceLocator.Singleton.Get<GlobalLight>();
        _speedBlackout  = speedBlackoutIn;
        _speedShine = speedShineIn;
        _isLight = true;
        _degree = 1f;
    }
    public Light2D Light => _globalLight.Light;
    public void ChangeLight(bool isActive)
    {
        _isLight = isActive;
    }
    public void Run()
    {
        if (_isLight)
            _degree -= _speedBlackout * Time.deltaTime;
        else
            _degree += _speedShine * Time.deltaTime;

        _degree = Mathf.Clamp(_degree, 0f, 1f);
        Light.color = Color.Lerp(
            _globalLight.BlackColor, 
            _globalLight.BrightColor, 
            _degree);
    }
}
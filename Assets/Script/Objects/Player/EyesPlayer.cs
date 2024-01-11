using UnityEngine;

public class EyesPlayer
{
    private bool _isLight;
    private float _degree;
    private Color _blackColor;
    private Color _minColor;

    public EyesPlayer()
    {
        _isLight = true;
        _degree = 1f;
        _blackColor = GameController.MaxLight;
        _minColor = GameController.MinLight;
    }
    public void ChangeLight(bool isActive)
    {
        _isLight = isActive;
    }
    public void Run()
    {
        var light = GameController.GlobalLight;
        if (_isLight)
            _degree -= Time.deltaTime;
        else
            _degree += Time.deltaTime;
        _degree = Mathf.Clamp(_degree, 0f, 1f);
        light.color = Color.Lerp(_blackColor, _minColor, _degree);
    }
}
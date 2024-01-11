using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BlackoutView : IService
{
    [SerializeField] private Image _blackFon;
    public BlackoutView(Image imageIn)
    {
        _blackFon = imageIn;
    }
    public IEnumerator Work(float speedIn)
    {
        yield return ViewOn(speedIn);
        yield return new WaitForSecondsRealtime(1f);
        yield return ViewOff(speedIn);
    }
    private IEnumerator ViewOn(float speedIn)
    {
        var color = _blackFon.color;
        while (_blackFon.color.a < 1f)
        {
            color.a += speedIn * Time.deltaTime;
            _blackFon.color = color;
            yield return null;
        }
    }
    private IEnumerator ViewOff(float speedIn)
    {
        var color = _blackFon.color;
        while (_blackFon.color.a > 0f)
        {
            color.a -= speedIn * Time.deltaTime;
            _blackFon.color = color;
            yield return null;
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextView
{
    private const float SPEED_READ = 8f;
    private static float _minSecond = 3f;

    private Image _fonText;
    private Text _text;
    public TextView(Image fonText, Text text)
    {
        _fonText = fonText;
        _text = text;
        this.SetAction(false);
    }

    public IEnumerator PrintText(TextData dataIn)
    {
        this.SetAction(true);
        var textData = dataIn;
        while (textData != null)
        {
            float second = textData.Text.Length / SPEED_READ;
            _text.text = textData.Text;
            yield return new WaitForSeconds(Mathf.Max(second, _minSecond));
            textData = textData.NextText;
        } 

        this.SetAction(false);
    }
    private void SetAction(bool isActionIn)
    {
        _fonText.enabled = isActionIn;
        _text.enabled = isActionIn;
    }
}

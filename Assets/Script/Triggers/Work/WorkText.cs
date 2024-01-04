using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkText : AbstractAction
{
    [SerializeField] private List<TextData> _datas;

    public override void Run(GameEventArgs args)
    {
        var _data = _datas[0];
        if (_data == null)
            throw new System.Exception("ƒанного текста нет в списке или не существует.");

        var view = GameCore.PanelSingleton.TextView;
        StartCoroutine(view.PrintText(_data));
    }
    public void RunText(string nameDatasData)
    {
        var _data = _datas.FirstOrDefault(_data => _data.Name == nameDatasData);
        if (_data == null)
            throw new System.Exception("ƒанного текста нет в списке или не существует.");

        var view = GameCore.PanelSingleton.TextView;
        StartCoroutine(view.PrintText(_data));
    }
}

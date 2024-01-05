using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkText : AbstractAction
{
    [SerializeField] private DialogData _data;

    public override void Run(GameEventArgs args)
    {
        if (_data == null)
            throw new System.Exception("ƒанного текста нет в списке или не существует.");

        var view = GameCore.PanelSingleton.TextView;
        StartCoroutine(view.PrintText(_data));
    }
    public void RunOtherText(string nameDatasDataIn)
    {
        var _data = GameCore.GetDialog(nameDatasDataIn);
        if (_data == null)
            throw new System.Exception("ƒанного текста нет в списке или не существует.");

        var view = GameCore.PanelSingleton.TextView;
        StartCoroutine(view.PrintText(_data));
    }
}

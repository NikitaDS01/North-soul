using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkText : Trigger
{
    [SerializeField] private DialogData _data;

    public override void Run(GameEventArgs args)
    {
        var view = GameController.Panel.TextView;
        StartCoroutine(view.PrintText(_data));
    }
    public void RunOtherText(string nameDatasDataIn)
    {
        var _data = GameController.TryGetDialog(nameDatasDataIn);
        if (_data == null)
            throw new System.Exception("ƒанного текста нет в списке или не существует.");

        var view = GameController.Panel.TextView;
        StartCoroutine(view.PrintText(_data));
    }

    protected override void Work()
    {
        throw new System.NotImplementedException();
    }
    protected override void NotWork()
    {
        base.NotWork();
    }
}

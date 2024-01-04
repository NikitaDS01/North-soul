using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : AbstractAction
{
    [SerializeField] private ItemData _item;
    [SerializeField] private bool _isShowText = true;
    public override void Run(GameEventArgs args)
    {
        if (Input.GetKeyUp(Settings.KeyUse))
        {
            var textView = GameCore.PanelSingleton.TextView;
            var player = GameCore.PlayerSingleton;
            var inventory = player.Inventory;
            string text = string.Empty;
            if (inventory.IsTherePlace())
            {
                text = $"�� ������� ������� - {_item.Name}";
                player.Inventory.Add(_item);
            }
            else
            {
                text = "��� ����� � ��������";
            }
            if (_isShowText)
                StartCoroutine(textView.PrintText(text));
        }
    }
    private void Start()
    {
        
    }
}
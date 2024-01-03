using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : AbstractWork
{
    [SerializeField] private ItemData _item;
    public override void Run(GameEventArgs args)
    {
        if (Input.GetKeyUp(Settings.KeyUse))
        {
            var player = GameCore.PlayerSingleton;
            var inventory = player.Inventory;
            if (inventory.IsTherePlace())
            {
                player.Inventory.Add(_item);
            }
            else
            {
                Debug.Log("Нет места в карманах");
            }
        }
    }
    private void Start()
    {
        
    }
}
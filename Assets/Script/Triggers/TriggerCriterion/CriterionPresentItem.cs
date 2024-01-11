using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Для работы триггера нужен предмет.
/// </summary>
public class CriterionPresentItem : ITriggerCriterion
{
    private ItemData _data;
    private Player _player;
    public CriterionPresentItem(ItemData dataIn)
    {
        _data = dataIn;
        _player = GameController.Player;
    }

    public bool Check()
    {
        var inventory = _player.Inventory;
        return inventory.Contain(_data);
    }
}

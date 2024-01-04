public class CriterionDoneAction : ITriggerCriterion
{
    private string _nameAction;

    public CriterionDoneAction(string nameActionIn)
    {
        _nameAction = nameActionIn;
    }

    public bool Check()
    {
        return GameCore.ContainAction(_nameAction);
    }
}
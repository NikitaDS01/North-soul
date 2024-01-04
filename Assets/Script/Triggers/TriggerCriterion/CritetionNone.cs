using System;

public class CritetionNone : ITriggerCriterion
{
    public CritetionNone() { }
    public bool Check()
    {
        return true;
    }
}
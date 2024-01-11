using System.Collections.Generic;

/// <summary>
/// Класс, нужен для хранения выполненых действий
/// </summary>
public class CompletedActions : IService
{
    private List<string> _completedActionData;

    public CompletedActions()
    {
        _completedActionData = new List<string>();
    }
    public bool Contain(string actionIn)
    {
        return _completedActionData.Contains(actionIn);
    }
    public void Add(string actionIn)
    {
        _completedActionData.Add(actionIn);
    }
}
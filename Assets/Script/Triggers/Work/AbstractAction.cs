using UnityEngine;
/// <summary>
/// Абстрактный класс для событий с входным параметром In
/// </summary>
/// <typeparam name="In">Входной параметр</typeparam>
public abstract class AbstractAction<In> : MonoBehaviour
{
    public abstract void Run(In objectIn, GameEventArgs args);
}
/// <summary>
/// Абстрактный класс для событий
/// </summary>
public abstract class AbstractAction : MonoBehaviour
{
    public abstract void Run(GameEventArgs args);
}

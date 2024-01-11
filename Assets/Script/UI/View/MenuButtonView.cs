using UnityEngine;

[System.Serializable]
public class MenuButtonView : IService
{
    [SerializeField] private GameObject _menuObject;

    public MenuButtonView(GameObject menuObjectIn)
    {
        _menuObject = menuObjectIn;
    }
    public void ViewOn()
    {
        _menuObject.SetActive(true);
    }
    public void ViewOff()
    {
        _menuObject.SetActive(false);
    }
}

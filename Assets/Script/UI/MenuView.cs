using UnityEngine;

public class MenuView
{
    private GameObject _menuObject;

    public MenuView(GameObject menuObjectIn)
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

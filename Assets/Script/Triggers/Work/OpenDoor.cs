using UnityEngine;

public class OpenDoor : AbstractAction
{
    [SerializeField]
    private GameObject _doorOpen;
    [SerializeField]
    private GameObject _doorClose;
    [SerializeField]
    private bool _isOpenDoor = false;

    private void Start()
    {
        ChangeDoor();
    }

    public override void Run(GameEventArgs args)
    {
        if (Input.GetKeyUp(Settings.KeyUse))
        {
            _isOpenDoor = !_isOpenDoor;
            ChangeDoor();
        }
    }
    private void ChangeDoor()
    {
        if (_isOpenDoor)
            Open();
        else
            Close();
    }
    private void Open()
    {
        _doorClose.SetActive(false);
        _doorOpen.SetActive(true);
    }
    private void Close()
    {
        _doorClose.SetActive(true);
        _doorOpen.SetActive(false);
    }
    private void Update()
    {

    }
}

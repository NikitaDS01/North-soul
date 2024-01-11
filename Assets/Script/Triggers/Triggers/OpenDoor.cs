﻿using UnityEngine;

public class OpenDoor : Trigger
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
    protected override void Work()
    {
        _isOpenDoor = !_isOpenDoor;
        ChangeDoor();
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
}
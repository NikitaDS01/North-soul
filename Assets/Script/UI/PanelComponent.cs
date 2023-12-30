﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Данный класс хранит все элементы Canvas, которые необходимо менять
/// </summary>
public class PanelComponent : MonoBehaviour
{
    [Header("Текстовый часть")]
    [SerializeField] private Image _fonText;
    [SerializeField] private Text _text;
    [Header("Инвентарь")]
    [SerializeField] private GameObject _inventoryViewObject;
    [SerializeField] private Image[] _images;
    [Header("Остальное")]
    [SerializeField] private Image _blackFon;
    [SerializeField] private GameObject _menu;

    private TextView _textView;
    private InventoryView _inventoryView;
    private bool _isMenuAction;

    private void Start()
    {
        _textView = new TextView(_fonText, _text);
        _inventoryView = new InventoryView(_inventoryViewObject, _images);
        _isMenuAction = false;
        this.MenuOff();
    }
    private void LateUpdate()
    {
        if (Input.GetKeyUp(Settings.KeyEcs))
        {
            if (_isMenuAction)
            {
                MenuOff();
                _isMenuAction = false;
            }
            else
            {
                MenuOn();
                _isMenuAction = true;
            }
        }
    }

    public TextView TextView => _textView;

    public void MenuOn()
    {
        Time.timeScale = 0f;
        _menu.SetActive(true);
        _inventoryView.ViewOn();
    }
    public void MenuOff()
    {
        Time.timeScale = 1f;
        _menu.SetActive(false);
        _inventoryView.ViewOff();
    }
    public IEnumerator TransitionOn(float second, float speed)
    {
        while(_blackFon.color.a != 1)
        {
            var color = _blackFon.color;
            color.a += speed;
            _blackFon.color = color;
            yield return new WaitForSeconds(second);
        }
    }
    public IEnumerator TransitionOff(float second, float speed)
    {
        while (_blackFon.color.a != 0)
        {
            var color = _blackFon.color;
            color.a -= speed;
            _blackFon.color = color;
            yield return new WaitForSeconds(second);
        }
    }
}

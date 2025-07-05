using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RadialLayout : MonoBehaviour
{
    public UnityAction<RadialMenuItem> SelectionChanged;

    private RadialMenuItem[] _radialMenuItems;

    private RadialMenuItem _selectedItem;

    private Vector2 _mousePosition;

    private Vector2 _screenCenter;

    public int itemAngle;

    public void OnPoint(InputValue value)
    {
        _mousePosition = Camera.main.ScreenToViewportPoint(value.Get<Vector2>());
    }

    public void OnClick()
    {
        _selectedItem.Clicked();
    }

    private void Awake()
    {
        _radialMenuItems = GetComponentsInChildren<RadialMenuItem>();
        float rotation = 0;
        foreach (var item in _radialMenuItems)
        {
            item.GetComponent<Image>().fillAmount = 1f / _radialMenuItems.Length;
            item.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, rotation));
            rotation += 360f / _radialMenuItems.Length;
        }
        itemAngle = 360 / _radialMenuItems.Length;
        _screenCenter = Camera.main.ScreenToViewportPoint(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void Update()
    {
        var currentAngle = Mathf.Atan2(_mousePosition.y - _screenCenter.y, _mousePosition.x - _screenCenter.x) * Mathf.Rad2Deg;
        if (currentAngle < 0) currentAngle += 360;

        var index = Convert.ToInt32(currentAngle / itemAngle) - 1;

        if(_selectedItem != _radialMenuItems[index])
        {
            _selectedItem = _radialMenuItems[index];
            SelectionChanged?.Invoke(_selectedItem);
        }        
    }
}

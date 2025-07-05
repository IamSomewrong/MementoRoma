using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    private GameObject _radialMenu;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _radialMenu = GameObject.FindGameObjectWithTag("RadialMenu");
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.SwitchCurrentActionMap("Player");
        _radialMenu.SetActive(false);
    }

    public void OnRadialMenu()
    {
        _radialMenu.SetActive(!_radialMenu.activeSelf);

        if (_playerInput.currentActionMap.name == "UI")
        {
            _playerInput.SwitchCurrentActionMap("Player");
        }
        else
        {
            _playerInput.SwitchCurrentActionMap("UI");
        }

    }

    public void OnPoint(InputValue value)
    {
        _radialMenu.GetComponentInChildren<RadialLayout>().OnPoint(value);
    }

    public void OnClick()
    {
        _radialMenu.GetComponentInChildren<RadialLayout>().OnClick();
    }
}

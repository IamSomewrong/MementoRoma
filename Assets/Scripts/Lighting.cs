using UnityEngine;
using UnityEngine.Rendering;

public class Lighting : MonoBehaviour
{
    private float _lightResource = 20f;
    private float _lightReduceSpeed = 0.1f;
    private Light _lightObject;

    private void Awake()
    {
        _lightObject = GetComponentInChildren<Light>();
    }

    void Update()
    {
        _lightResource -= _lightReduceSpeed * Time.deltaTime;
        _lightObject.intensity = _lightResource;
    }
}

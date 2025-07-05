using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Movable : MonoBehaviour
{
    private Rigidbody _rigidBody;

    private Transform _transform;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    private Vector2 _speed = Vector2.zero;

    private float _linearSpeedMultiplier = 0.5f;

    private float _maxLinearSpeed = 5f;

    public void OnMove(InputValue value)
    {
        var v = value.Get<Vector2>();
        _speed = v;
    }

    private float _rotationDelta = 0;

    public void OnLook(InputValue value)
    {
        var v = value.Get<Vector2>();

        _rotationDelta = v.x;
    }

    private bool _isDashing = false;

    public void OnDash()
    {
        print("dash");
        _isDashing = true;
    }

    private void FixedUpdate()
    {
        var multipliedSpeed = _speed * _linearSpeedMultiplier;
        var targetVelocity = _transform.TransformDirection(new Vector3(multipliedSpeed.x, 0, multipliedSpeed.y));

        _rigidBody.linearVelocity = Vector3.ClampMagnitude(_rigidBody.linearVelocity + targetVelocity, _maxLinearSpeed);
        if(_isDashing)
        {
            _rigidBody.linearVelocity *= 10f;
            _isDashing = false;
        }

        _rigidBody.angularVelocity = new Vector3(0, -_rotationDelta, 0);

    }
}


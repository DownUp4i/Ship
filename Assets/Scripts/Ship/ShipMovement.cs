using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private WindController _wind;
    [SerializeField] private SailController _sailController;

    private float _speedRotation = 20f;
    private float _speedIncline = 7f;

    private float _rotation;
    private float _incline;

    private float _dotProduct;

    private float _currentSpeed;

    private void Update()
    {
        Move();

        _speedRotation = _currentSpeed * 5f;

        _incline = Mathf.Clamp(_incline, -_speedIncline, _speedIncline);

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            _incline = Mathf.Lerp(_incline, 0f, 2f * Time.deltaTime);

        Debug.Log(_incline);

        if (Input.GetKey(KeyCode.A))
        {
            if (_currentSpeed > 0f)
            {
                _rotation += -_speedRotation * Time.deltaTime;

                _incline += -_speedIncline * Time.deltaTime;
                _incline = Mathf.Lerp(_incline, _speedIncline, 2f * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (_currentSpeed > 0f)
            {
                _rotation += _speedRotation * Time.deltaTime;

                _incline += -_speedIncline * Time.deltaTime;
                _incline = Mathf.Lerp(_incline, _speedIncline, 2f * Time.deltaTime);
            }
        }

        transform.localRotation = Quaternion.Euler(0f, _rotation, _incline);

        SetDotProduct();
    }

    private void SetDotProduct()
    {
        foreach (Transform sail in _sailController.Sails)
        {
            _dotProduct = Vector3.Dot(_wind.Direction, sail.forward);
        }
    }

    private void Move()
    {
        float speed = _wind.Force * _dotProduct;

        _currentSpeed = Mathf.Lerp(_currentSpeed, speed, 1f * Time.deltaTime);

        if (_currentSpeed > 0)
            transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime, Space.Self);
        else
            _currentSpeed = 0f;
    }
}
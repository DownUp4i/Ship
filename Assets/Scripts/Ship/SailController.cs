using System.Collections.Generic;
using UnityEngine;

public class SailController : MonoBehaviour
{
    [SerializeField] private List<Transform> _sails;
    [SerializeField] private WindController _windController;

    private float _speedRotation = 40f;
    private float _rotation = Mathf.DeltaAngle(0f, 360f);

    public List<Transform> Sails => _sails;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            _rotation += -_speedRotation * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            _rotation += _speedRotation * Time.deltaTime;

        _rotation = Mathf.Clamp(_rotation, -45f, 45f);

        foreach (Transform sail in _sails)
        {
            sail.localRotation = Quaternion.Euler(0f, _rotation, 0f);
        }
    }
}

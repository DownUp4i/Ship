using UnityEngine;

public class WindController : MonoBehaviour
{
    [SerializeField] private float _force;
    private float _time;

    private Vector3 _direction;
    private float _angle;

    public Vector3 Direction => _direction.normalized;
    public float Force => _force;

    private void Awake()
    {
        SetRandomAngle();
        _time = 0f;
        transform.rotation = Quaternion.Euler(0f, _angle, 0f);
    }
    private void Update()
    {
        _direction = transform.forward;

        _time += Time.deltaTime;

        if (_time > 5f)
        {
            SetRandomAngle();
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);
            _time = 0;
        }
    }

    private void SetRandomAngle()
    {
        _angle = Random.Range(0, 360);
    }
}

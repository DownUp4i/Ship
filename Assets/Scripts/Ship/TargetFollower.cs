using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _follower;
    [SerializeField] Vector3 _offset;

    private void Update()
    {
        _target.position = _follower.position + _offset;
    }
}

